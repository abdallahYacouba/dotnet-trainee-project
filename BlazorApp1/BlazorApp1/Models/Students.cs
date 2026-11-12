using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models;
public class Students
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? FirstName { get; set; }
    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }
}
