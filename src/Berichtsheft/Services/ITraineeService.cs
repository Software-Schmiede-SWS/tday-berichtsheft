using Services.DTO;

namespace Services;

public interface ITraineeService
{
    /// <summary>
    /// gib alle Einträge des Azubis zurück
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
    /// Erstelle Bericht für Kalenderwoche KW + die darauffolgende
    /// </summary>
    /// <param name="KW">Start Kalenderwoche (ungerade)</param>
    /// <returns></returns>
    CreateReportDTO CreateReport(int KW);
    /// <summary>
    /// gib Bericht mit allen Einträgen anhand KW zurück
    /// </summary>
    /// <param name="KW"></param>
    /// <returns></returns>
    ReportDTO GetReport(int KW);
    /// <summary>
    /// gib Berichte anhand Status zurück
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    ReportDTO[] GetReportsForState(EState State);
}
