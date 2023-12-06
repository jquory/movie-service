using System.Text.Json.Serialization;

namespace dummy_api.Shared.DTOs.Movie;

public class MovieResponse
{
    [JsonPropertyName("id")]
    public Guid? Id { get; set; }

    [JsonPropertyName("title")] 
    public string? Title { get; set; }
    
    [JsonPropertyName("releaseDate")] 
    public DateTime? ReleaseDate { get; set; }
    
    [JsonPropertyName("duration")] 
    public int? Duration { get; set; }
    
    [JsonPropertyName("synopsis")] 
    public string? Synopsis { get; set; }
    
    [JsonPropertyName("director")] 
    public string? Director { get; set; }
    
    [JsonPropertyName("genre")] 
    public string? Genre { get; set; }
    
}
