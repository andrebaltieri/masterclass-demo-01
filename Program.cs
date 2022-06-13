using Blog.Extensions;

var builder = WebApplication.CreateBuilder(args);

var host = builder.Configuration.GetValue<string>("Host");
List<Post> posts = new();

var app = builder.Build();
app.MapPost("v1/posts", (CreatePostModel model) =>
{
    var slug = model.Title.ToUrl();
    var post = new Post
    (
        posts.Count + 1,
        model.Title,
        slug,
        model.Body,
        $"{host}/v1/posts/{slug}",
        DateTime.UtcNow,
        DateTime.UtcNow
    );
    posts.Add(post);
    return Results.Created("v1/posts", post);
});

app.MapGet("v1/posts", ()
    => Results.Ok(posts));

app.MapGet("v1/posts/{slug}", (string slug)
    => Results.Ok(posts.FirstOrDefault(x => x.Slug == slug)));


app.Run();

public record CreatePostModel(string Title, string Body);

public record Post(int Id, string Title, string Slug, string Body, string Url, DateTime CreatedAt, DateTime UpdatedAt);