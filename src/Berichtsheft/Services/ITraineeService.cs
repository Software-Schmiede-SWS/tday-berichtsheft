using Services.DTO;

namespace Services;

public interface ITraineeService
{
    /// <summary>
    /// gib alle Eintr�ge des Azubis zur�ck
    /// </summary>
    /// <returns></returns>
    EntryDTO[] GetAllEntries();
    /// <summary>
    /// aktualisiere Eintrag
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    bool TryUpdateContent(string ID);
    /// <summary>
    /// Erstelle Bericht f�r Kalenderwoche KW + die darauffolgende
    /// </summary>
    /// <param name="KW">Start Kalenderwoche (ungerade)</param>
    /// <returns></returns>
    CreateReportDTO CreateReport(int KW);
    /// <summary>
    /// gib Bericht mit allen Eintr�gen anhand KW zur�ck
    /// </summary>
    /// <param name="KW"></param>
    /// <returns></returns>
    ReportDTO GetReport(int KW);
    /// <summary>
    /// gib Berichte anhand Status zur�ck
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    ReportDTO[] GetReportsForState(EState State);
}
