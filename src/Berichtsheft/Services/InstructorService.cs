using Berichtsheft.Data;
using Services.DTO;

namespace Services;

public class InstructorService(IReportRepository repository) : IInstructorService
{
    public EntryDTO[] GetPendingEntrys()
    {
        throw new NotImplementedException();
    }

    public void SubmitReview(string ID, string Comment)
    {
        throw new NotImplementedException();
    }
}
