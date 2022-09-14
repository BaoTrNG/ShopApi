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
        ///      

        ///create user  
        public async Task Create(Users user) =>
          await _users.InsertOneAsync(user);
        //check id if exist

        public async Task<Users> CheckIdJson(Users user) =>
          await _users.Find(m => m.Id == user.Id).FirstOrDefaultAsync();
        //check email if exist
        public async Task<Users> CheckEmailJson(Users user) =>
          await _users.Find(m => m.Email == user.Email).FirstOrDefaultAsync();
        ///


        //   public async Task<Users> FindUser(string id) => await _users.
        // await _users.Find(m => m.Id == id).FirstOrDefaultAsync();


        /*  public async Task Update(string id, Shop updateMovie) =>
              await _movies.ReplaceOneAsync(m => m.Id == id, updateMovie);

          public async Task Remove(string id) =>
              await _movies.DeleteOneAsync(m => m.Id == id); */

    }
}
