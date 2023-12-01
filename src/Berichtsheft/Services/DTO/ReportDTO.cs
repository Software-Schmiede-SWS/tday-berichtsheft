namespace Services.DTO;

// DTO nur für Erstelle Bericht
public readonly record struct CreateReportDTO((EntryDTO Entry, bool Valid)[] SubmittedEntries);
public readonly record struct ReportDTO((EntryDTO Entry, string Comment, EState State)[] Entries);
