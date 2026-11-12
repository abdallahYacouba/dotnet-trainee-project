using CityInf.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInf.Api.Controllers
{
    [ApiController] 
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        { 
            return Ok(CitiesDataStore.current.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id) {
            var cityToReturn = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == id);

            if(cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}
