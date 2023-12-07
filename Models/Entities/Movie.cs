using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dummy_api.Models.Entities;

[Table("Movie")]
public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    [Column("MovieID", Order = 1)]
    public Guid MovieId { get; set; }
    
    [Required]
    [Column("Title", Order = 2)]
    [MaxLength(510)]
    public string? Title { get; set; }
    
    [Column("ReleaseDate", Order = 3)]
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