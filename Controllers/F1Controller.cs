using BridgitCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BridgitCodingChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class F1Controller : ControllerBase
    {
        private readonly ILogger<F1Controller> _logger;

        public F1Controller(ILogger<F1Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRoot()
        {
            return BadRequest("Please use routes 'api/f1/{year}/standings' or 'api/f1/{year}/{round}/results'");
        }
        

        [HttpGet("{year}/standings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<DriverStanding>> GetStandings(int year)
        {
            if (year != 2021)
                return BadRequest("Only year allowed is 2021");

            Root root = JsonFileReader.Read<Root>("Data/driverStandings.json");
            return root.DriverStandings;
        }
    }

    public static class JsonFileReader
    {
        public static T Read<T>(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(text);
        }
    }
}