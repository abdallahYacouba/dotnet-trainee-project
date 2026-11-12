using System.ComponentModel.DataAnnotations;

namespace MicrosftValidation.Models;
public class TodoItem
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    [Required] public string Title { get; set; }
    public string Description { get; set; }
    public string Assignee { get; set; }
    [DeniedValues]
    public int Priority { get; set; }
    public bool IsComplete { get; set; }
}
