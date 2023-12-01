using System.ComponentModel.DataAnnotations.Schema;

namespace Berichtsheft.Data;

public class Report
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    public ApplicationUser Creator { get; set; } = null!;
    public IList<Entry>? Entries { get; set; }
    public ApplicationUser Instructor { get; set; } = null!;
}
