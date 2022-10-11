using TestAPI.ModelClass;
using TestAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ShopDbSetting>(builder.Configuration.GetSection("ShopDbSetting"));
builder.Services.AddSingleton<ServiceLogin>();
builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<TempCartService>();
builder.Services.AddSingleton<OrderService>();

//builder.Services.AddSingleton<Test>();


var app = builder.Build();
string art = "haha⠀ ";

app.MapGet("", () => art);




///////////////////////// USER SERVICE //////////////////////////


app.MapGet("/api/get", async (ServiceLogin moviesService) => await moviesService.Get());

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





///////////////////////////// ITEM SERVICE  //////////////////////////////

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


//đây là api để test json_list of object post method 
app.MapPost("/api/checkitem", async (UsersService service, List<CartItem> items) =>
{

    List<ResponseItems> responseItems = new List<ResponseItems>();
    List<ResponseItems> ErrorresponseItems = new List<ResponseItems>();
    foreach (var item in items)
    {
        ResponseItems code = new ResponseItems();
        var Check = await service.CheckRemain(item.ID, item.amount);
        Console.WriteLine(item.ID);
        Console.WriteLine(Check.Id);
        if (Check.Remain < item.amount)
        {
            ResponseItems temp = new ResponseItems();
            temp.Id = item.ID;
            ErrorresponseItems.Add(temp);
        }
    }
    if (ErrorresponseItems is null) // no error return empty list
    {
        Console.WriteLine("null");
        return responseItems;
    }
    else
    {
        Console.WriteLine("not null"); // return list of error item
        return ErrorresponseItems;
    }

});

//update item
app.MapPut("/api/finditem", async (UsersService service, CartItem item) =>
{
    var check = await service.FindItem(item);
    Console.WriteLine(check.Remain);
    check.Remain = check.Remain - item.amount;
    Console.WriteLine(check.Remain);
    await service.Update(check.Id, check);
    //return Results.Ok();
});








////////////////////////  TEMP CART SERVICE  //////////////////////////////

//find cart by id
app.MapPost("/api/findcart", async (TempCartService service, Carts temp) =>
{
    var check = await service.FindCart(temp);
    Carts cart = new Carts();
    if (check is null)
    {

        cart.Id = "0";
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

    await service.Update(temp.Id, temp);
    //return Results.Ok();
});





////////////////////////  ORDER SERVICE  /////////////////////////////
// tìm order theo tên user
app.MapPost("/api/findorder", async (OrderService service, Order temp) =>
{
    var check = await service.FindOrder(temp);

    return check;
});

app.MapGet("/api/getorder", async (OrderService service) => await service.Get());

//tạo order
app.MapPost("/api/createorder", async (OrderService service, Order temp) =>
{

    await service.Create(temp);
    return Results.Ok();

});

app.MapPost("/api/createp", async (OrderService service, Order temp) =>
{

    await service.CreateP(temp);
    return Results.Ok();

});

app.Run();
