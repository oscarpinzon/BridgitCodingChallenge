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

        [HttpGet("{year}/standings")]
        public IEnumerable<DriverStanding> Get()
        {
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