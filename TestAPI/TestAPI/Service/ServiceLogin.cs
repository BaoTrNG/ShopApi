using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestAPI.ModelClass;
using Microsoft.AspNetCore.Authorization;

namespace TestAPI.Data
{

    public class ServiceLogin
    {

        private readonly IMongoCollection<Users> _users;
        private readonly IConfiguration _config;
        public ServiceLogin(IOptions<ShopDbSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _users = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Users>("Users");
        }

        /// login
        //get all users
        public async Task<List<Users>> Get() =>
           await _users.Find(_ => true).ToListAsync();
        //auth user by url parameter
        public async Task<Users> GetUserURL(string id, string pass) =>
          await _users.Find(m => m.Id == id && m.Pass == pass).FirstOrDefaultAsync();
        //auth user by url parameter
        public async Task<Users> GetUserJson(Users user) =>
          await _users.Find(m => m.Id == user.Id && m.Pass == user.Pass).FirstOrDefaultAsync();

        public async Task<Users> GetPhone(string id) => await _users.Find(m => m.Id == id).FirstOrDefaultAsync();
        public async Task<Users> GetUserJson2(Users user) =>
  await _users.Find(m => m.Id == user.Id && m.Pass == user.Pass).FirstOrDefaultAsync();


        ///      

        ///create user  
        public async Task Create(Users user) =>
          await _users.InsertOneAsync(user);
        //check id if exist
        public async Task auth(Response res, Users user)
        {
            var find = await _users.Find(m => m.Id == user.Id && m.Pass == user.Pass).FirstOrDefaultAsync();

            if (find is null)
            {
                res.code = 0;
                res.msg = "User not found";

            }
            else
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("superSecretKey@345");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id)
                    }),
                    //   Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenhandler.CreateToken(tokenDescriptor);
                //  res.code = 1;
                res.msg = tokenhandler.WriteToken(token);
                if (find.Type == "ADMIN")
                {
                    res.code = 12;
                }
                else res.code = 11;
                //return tokenhandler.WriteToken(token);

            }
        }

        public async Task CreateUser(Response res, Users user)
        {

            var mongoClient = new MongoClient("mongodb+srv://AuthLogin:123@shopdb.40xjquu.mongodb.net/test");
            var session = mongoClient.StartSession();
            var USER = session.Client.GetDatabase("Shop").GetCollection<Users>("Users");
            var TEMPCART = session.Client.GetDatabase("Shop").GetCollection<Carts>("TempCarts");
            session.StartTransaction();
            try
            {
                Carts tempcart = new Carts();
                tempcart.Id = user.Id;
                tempcart.total = 0;
                tempcart.items = null;
                await USER.InsertOneAsync(session, user);
                await TEMPCART.InsertOneAsync(session, tempcart);
                res.code = 1;
                res.msg = "success";
                session.CommitTransaction();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception: " + e.Message);
                res.code = 0;
                res.msg = e.Message;
                session.AbortTransaction();
            }
        }






        public async Task<Users> CheckIdJson(Users user) =>
          await _users.Find(m => m.Id == user.Id).FirstOrDefaultAsync();
        //check email if exist
        public async Task<Users> CheckEmailJson(Users user) =>
          await _users.Find(m => m.Email == user.Email).FirstOrDefaultAsync();
        ///




        public async Task UpdatePhone(Response res, Users temp)
        {
            try
            {
                await _users.UpdateOneAsync(m => m.Id == temp.Id, Builders<Users>.Update.Set("Phone", temp.Phone));
                res.code = 1;
                res.msg = "ok";
                Console.WriteLine("ok");
            }
            catch (Exception e)
            {
                res.code = 0;
                res.msg = e.Message;
                Console.WriteLine(e.Message);
            }
        }

        public async Task UpdatePass(Response res, Users temp)
        {
            try
            {

                await _users.UpdateOneAsync(m => m.Id == temp.Id, Builders<Users>.Update.Set("Pass", temp.Pass));
                res.code = 1;
                res.msg = "ok";
                Console.WriteLine("ok");
            }
            catch (Exception e)
            {
                res.code = 0;
                res.msg = e.Message;
                Console.WriteLine(e.Message);
            }
        }



        //////////////ADMIN SERVICE//////////////////////
        public async Task<List<Users>> GetAllUser() =>
          await _users.Find(m => m.Type == "USER").ToListAsync();
        public void UpdateOrderAdmin(string id, Response res, Users user)
        {
            try
            {
                _users.ReplaceOne(m => m.Id == user.Id, user);
                res.code = 1;
                res.msg = "success";
            }
            catch (Exception e)
            {
                res.code = 0;
                res.msg = "failed";
            }
        }



    }
}
