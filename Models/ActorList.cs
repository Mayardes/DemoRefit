using System.Text.Json.Serialization;

namespace DemoRefit.Models;

public class ActorList
{
    //Specific property name from external api
    [JsonPropertyName("results")]
    public List<Actor> Actors {get; set;}
}