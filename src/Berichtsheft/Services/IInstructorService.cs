using Services;
using Services.DTO;

namespace Services;

public interface IInstructorService
{
    /// <summary>
    /// Gibt alle offenen Einträge des Ausbilders zurück. Sortiert nach Bearbeiter und Zeit (asc)
    /// </summary>
    /// <returns></returns>
    EntryDTO[] GetPendingEntrys();
    /// <summary>
    /// Erstellt ein Review für den Eintrag. Wenn der Kommentar leer ist, gilt der Eintrag als freigegeben
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="Comment"></param>
    void SubmitReview(string ID, string Comment);
}
