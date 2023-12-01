using Berichtsheft.Data;
using Microsoft.EntityFrameworkCore;
using Services.DTO;

namespace Services;

public class TraineeService(IReportRepository repository) : ITraineeService
{
    public CreateReportDTO CreateReport(int KW)
    {
        throw new NotImplementedException();
    }

    public EntryDTO[] GetAllEntries()
    {
        throw new NotImplementedException();
    }

    public ReportDTO GetReport(int KW)
    {
        throw new NotImplementedException();
    }

    public ReportDTO[] GetReportsForState(EState State)
    {
        throw new NotImplementedException();
    }

    public bool TryUpdateContent(string ID)
    {
        throw new NotImplementedException();
    }
}
