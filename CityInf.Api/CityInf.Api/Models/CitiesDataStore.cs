namespace CityInf.Api.Models;

public class CitiesDataStore
{
    public List<CityDto> Cities { get; set; }
    public static CitiesDataStore current { get; } = new CitiesDataStore();
    public CitiesDataStore()
    {
        Cities = new List<CityDto>() { 
 
            new CityDto(){ Id = 2, Name = "Antwerp", Description = "The one with cathedral that was never really find." },
            new CityDto(){ Id = 3, Name = "Paris", Description = "The one with that big tower." }
        };
    }
}
