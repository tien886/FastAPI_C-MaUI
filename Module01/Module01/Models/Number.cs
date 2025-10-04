
using System.Text.Json.Serialization;

namespace Module01.Models;

public class Number
{
    [JsonPropertyName("numbers")]
    
    public List<int> arr { get; set; }
    [JsonPropertyName("operators")]
    public string operation { get; set; }
}
