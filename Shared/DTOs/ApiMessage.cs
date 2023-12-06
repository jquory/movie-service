using System.ComponentModel;
using System.Text.Json.Serialization;

namespace dummy_api.Shared.DTOs;

public class ApiMessage<T>
{
    [JsonPropertyName("statusCode")]
    public int? StatusCode { get; set; }
    
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    
    [DefaultValue(null)]
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    
}