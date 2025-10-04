
using System.Text.Json.Serialization;

namespace MathOperations.Models;

public class Number
{
    [JsonPropertyName("numbers")]
    
    public List<int> arr { get; set; }
    [JsonPropertyName("operators")]
    public string operation { get; set; }
}
