using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dummy_api.Models.Entities;

[Table("Movie")]
public class Movie
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("MovieID", Order = 1)]
    public Guid? MovieId { get; set; }
    
    [Column("Title", Order = 2)]
    public string? Title { get; set; }
    
    [Column("ReleaseData", Order = 3)]
    [DefaultValue(null)]
    public DateTime? ReleaseDate { get; set; }
    
    [Column("Duration", Order = 4)]
    [DefaultValue(null)]
    public int? Duration { get; set; }
    
    [Column("Synopsis", Order = 5)]
    [DefaultValue(null)]
    public string? Synopsis { get; set; }
    
    [Column("DirectorID", Order = 6)]
    [DefaultValue(null)]
    public Guid? DirectorId { get; set; }

    [Column("GenreID", Order = 7)]
    [DefaultValue(null)]
    public Guid? GenreId { get; set; }
}