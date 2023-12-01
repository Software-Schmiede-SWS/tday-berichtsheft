namespace Berichtsheft.Data;

public class Report
{
    public string ID { get; set; }
    public ApplicationUser Creator { get; set; }
    public IList<Entry> Entries { get; set; }
    public EReportState State { get; set; }
}
