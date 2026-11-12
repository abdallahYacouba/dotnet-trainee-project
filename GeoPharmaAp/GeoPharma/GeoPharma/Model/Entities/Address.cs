namespace GeoPharma.Model.Entities;
public class Address
{
    public string? PhoneNumber1 { get; set; }
    public string? PhoneNumber2 { get; set; }
    public string? Email { get; set; }    
    /*=>*/
    public string District { get; set; } = "";
    public string Street { get; set; } = "";
    public string WebSiteUrl { get; set; } = "";
    public string YoutubeUrl { get; set; } = "";
    public string XUrl { get; set; } = "";
    public string FacebookUrl { get; set; } = "";
    public string LinkedInUrl { get; set; } = "";
    public string InstagramUrl { get; set; } = "";
    public string ZipCode { get; set; } = "";
}
