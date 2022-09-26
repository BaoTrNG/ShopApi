using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestAPI.ModelClass;

namespace TestAPI.Data
{
    public class TempService
    {

        private readonly IMongoCollection<TempsItems> _tempitems;

        public TempService(IOptions<ShopDbSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _tempitems = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<TempsItems>("Itemss");
        }
        public async Task<List<TempsItems>> GetAllItems() =>
          await _tempitems.Find(_ => true).ToListAsync();


    }
}
