using System.ComponentModel.DataAnnotations.Schema;

namespace Berichtsheft.Data;

public class Entry
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    public string Text { get; set; } = "";
}
