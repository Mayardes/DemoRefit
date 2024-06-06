using System.ComponentModel.DataAnnotations;
using DemoRefit.Models;
using DemoRefit.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoRefit.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieDbController(ITmdbApi tmdbApi) : ControllerBase
{
    private readonly ITmdbApi _tmdbApi = tmdbApi;

    [HttpGet("actors/")]
    public async Task<ActorList> GetActorsAsync([FromQuery][Required]string name)
    {
        var response = await _tmdbApi.GetActors(name);
        return response;
    }
}