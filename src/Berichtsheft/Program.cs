using Berichtsheft.Client.Pages;
using Berichtsheft.Components;
using Berichtsheft.Components.Account;
using Berichtsheft.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Berichtsheft.UiTests")]
[assembly: InternalsVisibleTo("Berichtsheft.UnitTests")]

namespace Berichtsheft;
public static class Program
{
    public static async Task Main(string[] args)
    {
        var app = BuildApp(args);

        await addTestUser(app, "azubi1@softwareschmiede.com", "Azubi");
        await addTestUser(app, "azubi2@softwareschmiede.com", "Azubi");
        await addTestUser(app, "ausbilder1@softwareschmiede.com", "Ausbilder");
        await addTestUser(app, "ausbidler2@softwareschmiede.com", "Ausbilder");

        app.Run();
    }

    public static async Task addTestUser(WebApplication app, string userName, string userRole)
    {
        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService <RoleManager<IdentityRole>>();
            if(roleManager.FindByNameAsync("Azubi").Result == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Azubi"));
            }

            if (roleManager.FindByNameAsync("Ausbilder").Result == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Ausbilder"));
            }

            var manager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            var delUser = await manager.FindByNameAsync(userName);
            if (delUser != null)
            {
                await manager.DeleteAsync(delUser);
            }

            // Standarduser anlegen wenn noch nicht vohanden
            var user = await manager.FindByNameAsync(userName);
            if (user == null)
            {
                var x = await manager.CreateAsync(new ApplicationUser
                {
                    UserName = userName,
                    Email = userName
                });
                // User nochmal holen da er jetzt existieren sollte
                var user2 = await manager.FindByNameAsync(userName);

                // Passwort setzen
                await manager.AddPasswordAsync(user2, "Test12!");
                await manager.AddToRoleAsync(user2, userRole);

                await manager.UpdateAsync(user2);
            }

        }

    }

    internal static WebApplication BuildApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<IdentityUserAccessor>();
        builder.Services.AddScoped<IdentityRedirectManager>();
        builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies();

        builder.Services.AddAuthorization(x =>
        {
            x.AddPolicy("Azubi", policy => policy.RequireRole("Azubi"));
            x.AddPolicy("Ausbilder", policy => policy.RequireRole("Ausbilder"));
        });

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

        builder.Services.AddScoped<IReportRepository, ReportRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapGroup("/account").MapIdentityApi<ApplicationUser>();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Counter).Assembly);

        // Add additional endpoints required by the Identity /Account Razor components.
        app.MapAdditionalIdentityEndpoints();

        return app;
    }
}
