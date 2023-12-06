using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dummy_api.Models.Entities;

[Table("Director")]
public class Director
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("DirectorID", Order = 1)]
    public Guid? DirectorId { get; set; }
    
    [Column("DirectorName", Order = 2)]
    public string? DirectorName { get; set; }
    
    [Column("BirthDate", Order = 3)]
    [DefaultValue(null)]
    public int? Duration { get; set; }
    
    [Column("Nationality", Order = 4)]
    [DefaultValue(null)]
    public DateTime? ReleaseData { get; set; }
    
}