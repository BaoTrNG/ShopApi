using TestAPI.ModelClass;
using TestAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ShopDbSetting>(builder.Configuration.GetSection("ShopDbSetting"));
builder.Services.AddSingleton<ServiceLogin>();
builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<TempCartService>();
builder.Services.AddSingleton<OrderService>();
builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    // options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;

    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),


        ValidateIssuer = false,
        ValidateAudience = false,
        //  ValidateLifetime = true,
        // ClockSkew = TimeSpan.Zero

    };
});

builder.Services.AddAuthorization();



var app = builder.Build();
app.UseHttpsRedirection();


string test = "test⠀ ";

app.MapGet("", () => test);




///////////////////////// USER SERVICE //////////////////////////

app.MapGet("/api/get", async (ServiceLogin moviesService) => await moviesService.Get()).RequireAuthorization();
app.MapGet("/api/test",
() => "Hello World!").RequireAuthorization();

app.MapPost("/api/loginv2", [AllowAnonymous] async (ServiceLogin login, Users user) =>
{
    Response res = new Response();
    await login.auth(res, user);
    return res;
    // return Check is null ? 0 : 1;
});


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
        if (Check.Status == "ok")
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
        else return 13; //banned acc
    }
    // return Check is null ? 0 : 1;
});
app.MapPost("/api/getadminphone", async (ServiceLogin login, Users user) =>
{

    var Check = await login.GetPhone(user.Id);

    return Check.Phone;
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

app.MapPost("/api/createuser", async (ServiceLogin service, Users user) =>
{
    Response res = new Response();
    await service.CreateUser(res, user);
    return res;
});

app.MapPut("/api/updatephone", async (ServiceLogin service, Users user) =>
{
    Response res = new Response();
    await service.UpdatePhone(res, user);
    return res;
});

app.MapPut("/api/updatepass", async (ServiceLogin service, Users user) =>
{
    Response res = new Response();
    await service.UpdatePass(res, user);
    return res;
});


/*app.MapPost("/api/createuser", async (ServiceLogin service, Users user) =>
{
    Response res = new Response();
    await service.CreateUser(res, user);
    return res;
}); */

/////////////////ADMIN USER SERVICE///////////////////
app.MapGet("/api/getalluser", async (ServiceLogin service) => await service.GetAllUser());
app.MapPut("/api/updateuseradmin", (ServiceLogin service, Users user) =>
{
    Response res = new Response();
    service.UpdateOrderAdmin(user.Id, res, user);
    return res;
});


///////////////////////////// ITEM SERVICE  //////////////////////////////

//Find all items
app.MapGet("/api/getitems", async (UsersService service) => await service.GetAllItems());

app.MapGet("/api/getitemsv2", async (UsersService service) => await service.GetAllItems()).RequireAuthorization();

app.MapGet("/api/checkremain/{id}/{remain}", async (UsersService service, string id, int remain) =>
{
    var check = await service.CheckRemain(id, remain);
    if (check is null) return 0;
    else if (check.Remain < remain)
    {
        return 2;
    }
    else return 1;
});

app.MapPut("/api/updateitem/", async (UsersService service, Items temp) =>
{
    Response res = new Response();
    CartItem tempcart = new CartItem();
    tempcart.ID = temp.Id;
    var check = await service.FindItem(tempcart);
    if (check is null)
    {
        res.code = 0;
        res.msg = "Không Tìm Thấy Món Hàng";
        return res;
    }
    else
    {
        await service.Update(res, temp.Id, temp);
        return res;
    }
});


app.MapPost("/api/createitem", async (UsersService service, Items temp) =>
{
    Response res = new Response();
    await service.Create(res, temp);
    return res;
});

app.MapDelete("/api/deleteitem/{id}", async (UsersService service, string id) =>
{
    Response res = new Response();
    CartItem temp = new CartItem();
    temp.ID = id;
    var check = await service.FindItem(temp);
    if (check is null)
    {
        res.code = 0;
        res.msg = "Không Tìm Thấy Món Hàng";
        return res;
    }
    else
    {
        await service.Delete(res, id);
        return res;
    }
});






app.MapPost("/api/checkitemv2", async (UsersService service, List<CartItem> items) =>
{

    ResponseItems responseItems = new ResponseItems();
    responseItems.code = "ok";
    responseItems.Id = new List<string>();

    ResponseItems ErrorresponseItems = new ResponseItems();
    ErrorresponseItems.code = "error";
    ErrorresponseItems.Id = new List<string>();

    ResponseItems NullItems = new ResponseItems();
    NullItems.code = "null";
    NullItems.Id = new List<string>();
    foreach (var item in items)
    {
        Console.WriteLine(item.ID);
        ResponseItems code = new ResponseItems();
        var Check = await service.CheckRemain(item.ID, item.amount);

        if (Check is null)
        {
            String temp = item.ID;
            NullItems.Id.Add(temp);
        }
        else
        {
            if (Check.Remain < item.amount)
            {
                Console.WriteLine("not enough");
                String temp = item.ID;
                ErrorresponseItems.Id.Add(temp);
            }
        }
    }
    if (NullItems.Id.Count > 0)
    {
        Console.WriteLine("null");
        return NullItems;
    }
    else if (ErrorresponseItems.Id.Count > 0) //  error return ErrorresponseItems
    {
        Console.WriteLine("not enough item");
        return ErrorresponseItems;
        ;
    }
    else
    {
        Console.WriteLine("enough");
        Console.WriteLine("not null"); // return ok
        return responseItems;
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


app.MapGet("/api/checkitemid/{id}", async (UsersService service, string id) =>
{
    try
    {
        var check = await service.CheckItem(id);
        if (check is null)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    catch (Exception e)
    {
        return 2;
    }
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
/*app.MapPost("/api/createcart", async (TempCartService service, Carts temp) =>
{
    await service.Create(temp);
    return Results.Ok();
}); */

app.MapPost("/api/createcart", async (TempCartService service, Carts temp) =>
{
    Response res = new Response();
    await service.CreateCart(res, temp);
    return res;
});



app.MapPut("/api/updatecart", async (TempCartService service, Carts temp) =>
{
    Response res = new Response();
    await service.UpdateCart(res, temp.Id, temp);
    return res;
});




////////////////////////  ORDER SERVICE  /////////////////////////////
// tìm order theo tên user
app.MapPost("/api/findorder", async (OrderService service, Order temp) =>
{
    var check = await service.FindOrder(temp);
    return check;

});

app.MapPost("/api/userorders", async (OrderService service, Order target) =>
{
    Response res = new Response();
    await service.CountOrder(res, target.buyer);
    return res;
});

app.MapGet("/api/getorder", async (OrderService service) => await service.Get());
app.MapGet("/api/getorderstatus/{id}", async (OrderService service, string id) =>
{
    var check = await service.GetStatus(id);
    if (check is null)
    {
        return 0;
    }
    else
    {
        if (check.status == "canceled" || check.status == "delivering")
        {
            return 0;
        }
        else return 1;
    }
});



app.MapPost("/api/createorder", async (OrderService service, Order temp) =>
{
    Response res = new Response();
    await service.CreateOrder(res, temp);
    return res;

});
//tạo order
app.MapPost("/api/createp", async (OrderService service, Order temp) =>
{
    Response res = new Response();
    await service.CreateP(res, temp);
    return res;

});

app.MapPut("/api/updateorder", async (OrderService service, Order temp) =>
{
    Response res = new Response();
    await service.UpdateOrder(res, temp.Id, temp);
    return res;

});

app.MapPut("/api/updateorderadmin", async (OrderService service, Order temp) =>
{
    Response res = new Response();
    var check = await service.GetOrder(temp.Id);
    if (check is null)
    {
        res.code = 3;
        res.msg = "Order is not exist";
        return res;
    }
    else
    {
        await service.UpdateOrderAdmin(temp.Id, temp, res);
        return res;
    }
});

app.MapPut("/api/deleteorderadmin", async (OrderService service, Order temp) =>
{
    Response res = new Response();
    var check = await service.GetOrder(temp.Id);

    if (check is null)
    {
        res.code = 3;
        res.msg = "Order is not exist";
        return res;
    }
    else
    {
        service.DeleteOrderAdmin(temp.Id, res);
        return res;
    }
});


app.MapPost("/api/getlistadmin", async (OrderService service, Order temp) =>
{
    Response res = new Response();
    var check = await service.GetOrder(temp.Id);
    List<Admin> admin = new List<Admin>();
    admin = service.GetAdmin(temp.Id, admin);
    return admin;
});
app.UseAuthentication();
app.UseAuthorization();
app.Run();
