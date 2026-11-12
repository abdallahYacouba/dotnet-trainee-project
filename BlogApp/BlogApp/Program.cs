using BlogApp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlogAppDb>(
    o => o.UseSqlite(builder.Configuration["ConnectionStrings:BlogDatabase"]));

/* builder.Services.AddSwaggerGen(); */

var app = builder.Build();
/* if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} */


app.MapGet("/blog", (BlogAppDb context) =>
{
    var datafromDb = context.Blogs.ToList();
    return Results.Ok(datafromDb);
});

app.MapDelete("/blog/{id:int}", (int id, BlogAppDb context) =>
{
    var blog = context.Blogs.Find(id);
    if (blog == null)
    {
        return Results.NotFound();
    }
    context.Blogs.Remove(blog);
    context.SaveChanges();
    return Results.NoContent();
});


app.Run();
