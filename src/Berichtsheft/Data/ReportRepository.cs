namespace Berichtsheft.Data;

public class ReportRepository(ApplicationDbContext context) : IReportRepository
{
    public IEnumerable<Report> GetAll()
    {
        return context.Reports;
    }

    public Report? Get(string id)
    {
        return context.Reports.Find(id);
    }

    public void Add(Report report)
    {
        context.Reports.Add(report);
        context.SaveChanges();
    }

    public void Update(Report report)
    {
        context.Reports.Update(report);
        context.SaveChanges();
    }

    public void Delete(string id)
    {
        var report = context.Reports.Find(id);
        if (report != null)
        {
            context.Reports.Remove(report);
            context.SaveChanges();
        }
    }
}
