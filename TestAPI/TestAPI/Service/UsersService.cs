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

        public async Task<Items> FindItem(CartItem item) =>
           await _items.Find(m => m.Id == item.ID).FirstOrDefaultAsync();

        public async Task<Items> CheckItem(string id) =>
        await _items.Find(m => m.Id == id).FirstOrDefaultAsync();

        public async Task Update(string id, Items temp) =>
       await _items.ReplaceOneAsync(m => m.Id == id, temp);
        public async Task Update(Response res, string id, Items temp)
        {
            try
            {
                await _items.ReplaceOneAsync(m => m.Id == id, temp);
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

        public async Task Create(Response res, Items temp)
        {
            try
            {
                await _items.InsertOneAsync(temp);
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

        public async Task Delete(Response res, string id)
        {
            try
            {
                await _items.DeleteOneAsync(m => m.Id == id);
                res.code = 1;
                res.msg = "ok";
            }
            catch (Exception e)
            {
                res.code = 0;
                res.msg = e.Message;
            }
        }

    }
}
