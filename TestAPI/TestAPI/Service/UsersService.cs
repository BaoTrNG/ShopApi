using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestAPI.ModelClass;

namespace TestAPI.Data
{
    public class UsersService
    {

        private readonly IMongoCollection<Items> _items;

        public UsersService(IOptions<ShopDbSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _items = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Items>("Items");
        }
        public async Task<List<Items>> GetAllItems() =>
          await _items.Find(m => m.Remain > 0).ToListAsync();
        public async Task<Items> CheckRemain(string id, int remain) =>
         await _items.Find(m => m.Id == id).FirstOrDefaultAsync();




    }
}
