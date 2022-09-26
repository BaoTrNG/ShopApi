using TestAPI.ModelClass;
using TestAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ShopDbSetting>(builder.Configuration.GetSection("ShopDbSetting"));
builder.Services.AddSingleton<ServiceLogin>();
builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<TempService>();

var app = builder.Build();
string art = "haha⠀ ";


// get all users
app.MapGet("/api/get", async (ServiceLogin moviesService) => await moviesService.Get());
app.MapGet("", () => art);

/*app.MapPost("/api/movies", async (ServiceLogin moviesService, String id) =>
{
    await moviesService.FindUser(id);
    //var Login = await moviesService.FindUser(id);
    return Results.Ok();
}); */

//Auth user by url parameter
app.MapPost("/api/login/{id}/{pass}", async (ServiceLogin moviesService, string id, string pass) =>
{
    var Check = await moviesService.GetUserURL(id, pass);
    return Check is null ? 0 : 1; //Results.NotFound() : Results.Ok(movie);
});

//Auth User by json
app.MapPost("/api/login", async (ServiceLogin login, Users user) =>
{

    var Check = await login.GetUserJson(user);
    if (Check is null)
    {
        return 0;
    }
    else
    {
        if (Check.Type == "ADMIN")
        {
            return 12;
        }
        else
        {
            return 11;
        }
    }
    // return Check is null ? 0 : 1;
});



app.MapPost("/api/create/checkid", async (ServiceLogin registration, Users user) =>
{
    var Check = await registration.CheckIdJson(user);
    return Check is null ? 0 : 1;
});
app.MapPost("/api/create/checkemail", async (ServiceLogin registration, Users user) =>
{
    var Check = await registration.CheckEmailJson(user);
    return Check is null ? 0 : 1;
});


//Create new User
app.MapPost("/api/createUser", async (ServiceLogin service, Users user) =>
{
    await service.Create(user);
    return Results.Ok();
});





//Find all items
app.MapGet("/api/getitems", async (UsersService service) => await service.GetAllItems());



//find cart by id









/// <summary>
/// Update a movie
/// </summary>
/*app.MapPut("/api/movies/{id}", async (Service moviesService, string id, Shop updatedMovie) =>
{
    var movie = await moviesService.Get(id);
    if (movie is null) return Results.NotFound();

    updatedMovie.Id = movie.Id;
    await moviesService.Update(id, updatedMovie);

    return Results.NoContent();
});

/// <summary>
/// Delete a movie
/// </summary>
app.MapDelete("/api/movies/{id}", async (Service moviesService, string id) =>
{
    var movie = await moviesService.Get(id);
    if (movie is null) return Results.NotFound();

    await moviesService.Remove(movie.Id);

    return Results.NoContent();
});*/













app.Run();
