using MoviesAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MoviesDatabaseSettings>(builder.Configuration.GetSection("MoviesDatabaseSettings"));
builder.Services.AddSingleton<MoviesService>();
var app = builder.Build();

app.MapGet("/", () => "Movies API!");

app.MapGet("/api/movies", async(MoviesService moviesService) => await moviesService.Get());

app.MapGet("/api/movies/{id}", async(MoviesService moviesService, string id) => 
{ 
    var movie = await moviesService.Get(id);
    return movie is null ? Results.NotFound() : Results.Ok(movie);
});

app.MapPost("/api/movies", async (MoviesService moviesService, Movie movie) => 
{
    ////manually add the BsonDocument afterwards, not how I intend to do it ofc.
    //var bsonDocument = new BsonDocument
    //{
    //  { "name", "MongoDB2" },
    //  { "type", "Database2" },
    //  { "count", 2 },
    //  { "info", new BsonDocument
    //  {
    //    { "x", 255 },
    //    { "y", 111 }
    //  }}
    //};
    //movie.UnstructuredInfo = bsonDocument;

    await moviesService.Create(movie);
    return Results.Ok();
});

app.MapPut("/api/movies/{id}", async(MoviesService moviesService, string id, Movie updatedMovie) => 
{
    var movie = await moviesService.Get(id);
    if (movie is null) return Results.NotFound();

    updatedMovie.Id = movie.Id;
    await moviesService.Update(id, updatedMovie);

    return Results.NoContent();
});

app.MapDelete("/api/movies/{id}", async (MoviesService moviesService, string id) =>
{
    var movie = await moviesService.Get(id);
    if (movie is null) return Results.NotFound();

    await moviesService.Remove(movie.Id);

    return Results.NoContent();
});

app.Run();
