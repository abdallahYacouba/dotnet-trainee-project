using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeoPharma.Model.Entities;
public class Pharmacy : EntityBase
{
    public string? RCCM { get; set; }
    public string? Nif { get; set; }
    public string? Name { get; set; }
    public DateTime? CreateAt { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Localisation { get; set; } = "";
    public bool Status { get; set; }
    public Address? Address { get; set; }
    /*******************************************************
    ********************************************************
    ********************************************************
    *******************************************************/
    public Doctor? Doctor { get; set; }
    public Region? Region { get; set; }
    public Municipality? Municipality { get; set; }
}
