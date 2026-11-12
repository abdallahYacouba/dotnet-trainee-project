using System.ComponentModel.DataAnnotations;

namespace ApiTrainee.Models.Entities;
public class Trainee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 100 characters.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 100 characters.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    [DataType(DataType.Date)]
    // Example: DateOfBirth cannot be in the future, and assume a reasonable minimum age (e.g., 16 years ago)
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// (e.g., "Male", "Female", "Other")
    /// </summary>
    [Required(ErrorMessage = "Gender is required.")]
    [AllowedValues("Male", "Female", "Other", ErrorMessage = "Gender must be 'Male', 'Female', or 'Other'.")]
    public string? Gender { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    [StringLength(150, ErrorMessage = "Email Address cannot exceed 150 characters.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Phone Number is required.")]
    // A more flexible regex for phone numbers (can be adjusted for specific regional formats)
    [RegularExpression(@"^\+?[0-9\s\-\(\)]{7,20}$", ErrorMessage = "Invalid Phone Number format.")]
    [StringLength(20, ErrorMessage = "Phone Number cannot exceed 20 characters.")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Enrollment Date is required.")]
    [DataType(DataType.Date)]
    // EnrollmentDate cannot be in the future, and likely not too far in the past (e.g., within the last 5 years)
    public DateTime EnrollmentDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Name or ID of the program the trainee is enrolled in
    /// Cybersecurity, Cloud Computing, Data Science & Machine Learning (AI/ML)
    /// DevOps, Networking & System Administration, IT Support & Helpdesk
    /// Software Development, Design / Template
    /// </summary>
    [Required(ErrorMessage = "Training Program is required.")]
    [StringLength(100, ErrorMessage = "Training Program cannot exceed 100 characters.")]
    // You could also use a custom validation attribute or AllowedValues if the list is fixed
    public string? TrainingProgram { get; set; }

    /// <summary>
    /// (e.g., "Active", "Completed", "Withdrawn", "On Hold")
    /// </summary>
    [Required(ErrorMessage = "Status is required.")]
    // Assuming Status should be represented by a boolean, you might want to clarify its meaning.
    // If it's a string status, then use AllowedValues as below:
    [AllowedValues("Active", "Completed", "Withdrawn", "On Hold", ErrorMessage = "Status must be 'Active', 'Completed', 'Withdrawn', or 'On Hold'.")]
    public string? Status { get; set; } = "On Hold";

    /// <summary>
    /// (e.g., percentage completion of the program, 0.0 to 100.0)
    /// </summary>
    [Range(0.0f, 100.0f, ErrorMessage = "Progress must be between 0.0 and 100.0.")]
    public float Progress { get; set; }

    /// <summary>
    /// (General notes about the trainee)
    /// </summary>
    [StringLength(500, ErrorMessage = "Note cannot exceed 500 characters.")]
    public string? Note { get; set; }
    public string? AccessCode { get; set; }
}
