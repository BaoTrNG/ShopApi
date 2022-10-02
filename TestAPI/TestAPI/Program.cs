using TestAPI.ModelClass;
using TestAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ShopDbSetting>(builder.Configuration.GetSection("ShopDbSetting"));
builder.Services.AddSingleton<ServiceLogin>();
builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<TempCartService>();
//builder.Services.AddSingleton<Test>();


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


//đây là api để test json_list of object post method
app.MapPost("/api/login2", async (ServiceLogin login, List<Users> users) =>
{
    List<int> check = new List<int>();
    // Array
    List<ResponseItems> responseItems = new List<ResponseItems>();
    foreach (var user in users)
    {
        ResponseItems item = new ResponseItems();
        var Check = await login.GetUserJson(user);
        if (Check is null)
        {
            check.Add(0);
            item.Id = 0;
            responseItems.Add(item);
        }
        else
        {
            if (Check.Type == "ADMIN")
            {
                check.Add(12);
                item.Id = 12;
                responseItems.Add(item);

            }
            else
            {
                check.Add(11);
                item.Id = 11;
                responseItems.Add(item);
            }
        }
    }
    return responseItems;
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

app.MapGet("/api/checkremain/{id}/{remain}", async (UsersService service, string id, int remain) =>
{
    var check = await service.CheckRemain(id, remain);
    if (check.Remain < remain)
    {
        return 0;
    }
    else return 1;
});


//find cart by id
app.MapPost("/api/findcart", async (TempCartService service, Carts temp) =>
{
    var check = await service.FindCart(temp);
    Carts cart = new Carts();
    if (check is null)
    {

        cart.Id = "0";
        cart.buyer = "0";
        return cart;
    }
    else
    {
        return check;
    }
});

//create new temp cart
app.MapPost("/api/createcart", async (TempCartService service, Carts temp) =>
{
    await service.Create(temp);
    return Results.Ok();
});

//update temp cart
app.MapPut("/api/updatecart", async (TempCartService service, Carts temp) =>
{
    // var movie = await service.GetCart(temp);
    // if (movie is null) return Results.NotFound();
    //return Results.NoContent();

    await service.Update(temp.buyer, temp);
});





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
