namespace BlogApp.Model;
public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public DateTime Publish { get; set; }
    public bool Status { get; set; }
}
