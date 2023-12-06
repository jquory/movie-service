using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dummy_api.Models.Entities;

public class Genre
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("GenreID", Order = 1)]
    public Guid? GenreId { get; set; }
    
    [Column("GenreName", Order = 2)]
    public string? GenreName { get; set; }
    
}