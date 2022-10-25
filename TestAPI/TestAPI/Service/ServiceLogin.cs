using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestAPI.ModelClass;

namespace TestAPI.Data
{
    public class ServiceLogin
    {

        private readonly IMongoCollection<Users> _users;
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
                res.msg = "e.Message";
                session.AbortTransaction();
            }
        }






        public async Task<Users> CheckIdJson(Users user) =>
          await _users.Find(m => m.Id == user.Id).FirstOrDefaultAsync();
        //check email if exist
        public async Task<Users> CheckEmailJson(Users user) =>
          await _users.Find(m => m.Email == user.Email).FirstOrDefaultAsync();
        ///








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
