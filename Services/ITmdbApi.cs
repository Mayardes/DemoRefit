using DemoRefit.Models;
using Refit;

namespace DemoRefit.Services;

//You can set on or more static request headers for a request applying a HEADER attribute to the mothod
//As we will use token authentication with TMDB API, we need to add Authorization: Beader header in the interface
[Headers("accept: application/json", "Authorization: Bearer")]
public interface ITmdbApi
{
    //this is relative URL
    [Get("/search/person?query={name}")]
    Task<ActorList> GetActors ([AliasAs("name")] string actorName);
}


//Note that in Refit unlike in Retrofit, 
//there is no option for a synchronous network request - all requests mus be async, either via Task or via IObservable.