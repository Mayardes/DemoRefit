using System.Text.Json.Serialization;

namespace DemoRefit.Models;

public class Actor
{
    //Specific property name from external api
    [JsonPropertyName("id")]
    public int Id {get; set;}

    //Specific property name from external api
    [JsonPropertyName("name")]
    public string Name {get; set;}
}