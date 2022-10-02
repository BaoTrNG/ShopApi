using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using TestAPI.ModelClass;


namespace TestAPI.Data
{
    public class TempCartService
    {
        private readonly IMongoCollection<Carts> _temp;
        public TempCartService(IOptions<ShopDbSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _temp = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Carts>("Carts");
        }
        public async Task<List<Carts>> FindAll() =>
          await _temp.Find(_ => true).ToListAsync();
        public async Task<Carts> FindCart(Carts temp) =>
          await _temp.Find(m => m.buyer == temp.buyer).FirstOrDefaultAsync();


        public async Task Create(Carts temp) =>
          await _temp.InsertOneAsync(temp);
        public async Task Update(string buyer, Carts temp) =>
        await _temp.ReplaceOneAsync(m => m.buyer == buyer, temp);

    }
}
