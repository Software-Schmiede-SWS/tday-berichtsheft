namespace Berichtsheft.Services;

public class DummyService(ILogger<DummyService> logger) : IDummyService
{
    public bool DoSomething(bool fail)
    {
        logger.LogInformation("Doing something...");
        if (fail) throw new NotImplementedException("zum test");
        return true;
    }
}
