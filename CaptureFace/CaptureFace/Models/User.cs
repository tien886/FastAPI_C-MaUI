
using System.Text.Json.Serialization;

namespace CaptureFace.Models;

public class User
{
    [JsonPropertyName("Base64stringFaceOfUser")]
    public string Base64stringFaceOfUser { get; set; }  
    [JsonPropertyName("UserName")]
    public string UserName { get; set; }
    [JsonPropertyName("UserId")]
    public string UserId { get; set; }
}
