using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace weatherappapi.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase {
        private readonly ILocationsRepository locationsRepository;

        public LocationsController (ILocationsRepository locationsRepository) {
            this.locationsRepository = locationsRepository;
        }

        // GET api/locations/getcities?input={city}
        [HttpGet ("cities")]
        public async Task<ActionResult> Get (string input) {
            if(input?.Length < 2)
                return BadRequest("Input too generic");

            var result = await locationsRepository.GetCities(input);

            return Ok(result);
        }
    }
}