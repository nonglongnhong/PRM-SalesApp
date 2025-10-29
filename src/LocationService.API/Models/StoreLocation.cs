namespace LocationService.API.Models;

public class StoreLocation
{
    public int LocationID { get; set; }
    public decimal Latitude { get; set; }   
    public decimal Longitude { get; set; }  
    public string Address { get; set; } = default!;
}
