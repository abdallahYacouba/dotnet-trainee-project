namespace GeoPharma.Model.Entities;
public class Doctor : EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName { get => FirstName + " " + LastName; }
    public Address? Address { get; set; }
}
