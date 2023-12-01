using System.ComponentModel.DataAnnotations.Schema;

namespace Berichtsheft.Data;

public class Entry
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    public DateTime Date { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Created { get; set; }
    public string Text { get; set; } = "";
    public string Comment { get; set; } = "";
    public EReportState State { get; set; }
}
