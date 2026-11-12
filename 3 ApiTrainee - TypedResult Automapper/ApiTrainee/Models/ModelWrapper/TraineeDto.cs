using System.ComponentModel.DataAnnotations;

namespace ApiTrainee.Models.ModelWrapper;
public class TraineeDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
     /*public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
   public DateTime EnrollmentDate { get; set; }
    public string? TrainingProgram { get; set; }
    public string? Status { get; set; }
    public float Progress { get; set; }
    public string? Note { get; set; }*/
}
