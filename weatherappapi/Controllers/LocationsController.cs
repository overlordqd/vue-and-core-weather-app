using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weatherappapi.models;
using System.Net.Http;

namespace weatherappapi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase {
        private readonly ILocationsRepository locationsRepository;

        public LocationsController (ILocationsRepository locationsRepository) {
            this.locationsRepository = locationsRepository;
        }

        // GET api/locations/getcities?input={city}
        [HttpGet ("getcities")]
        public async Task<ActionResult> GetCities (string input) {
            if(input?.Length < 2)
                return BadRequest("Input too generic");

            var result = await locationsRepository.GetCities(input);

            return Ok(result);
        }
    }
}