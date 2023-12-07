using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dummy_api.Shared.DTOs.Movie;

public class MovieRequest
{
    [Required]
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [Required]
    [JsonPropertyName("releaseDate")]
    public DateTime? ReleaseDate { get; set; }
    
    [Required]
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }
    
    [Required]
    [JsonPropertyName("synopsis")]
    public string? Synopsis { get; set; }
    
    [Required]
    [JsonPropertyName("director")]
    public Guid? DirectorId { get; set; }
    
    [Required]
    [JsonPropertyName("directorName")]
    public string? DirectorName { get; set; }
    
    [Required]
    [JsonPropertyName("genre")]
    public Guid? GenreId { get; set; }

    [Required]
    [JsonPropertyName("genreName")]
    public string? GenreName { get; set; }
}