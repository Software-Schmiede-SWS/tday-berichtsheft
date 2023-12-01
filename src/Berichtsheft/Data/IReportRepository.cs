namespace Berichtsheft.Data;

public interface IReportRepository
{
    IEnumerable<Report> GetAll();
    Report Get(string id);
    void Add(Report report);
    void Update(Report report);
    void Delete(string id);
}
