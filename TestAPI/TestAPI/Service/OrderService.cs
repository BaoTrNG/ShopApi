using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TestAPI.ModelClass;

namespace TestAPI.Data
{
    public class OrderService
    {

        private readonly IMongoCollection<Order> _order;

        public OrderService(IOptions<ShopDbSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _order = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Order>("Order");
        }

        public async Task<List<Order>> Get() =>
           await _order.Find(_ => true).ToListAsync();
        public async Task<List<Order>> FindOrder(Order order) =>
           await _order.Find(m => m.buyer == order.buyer).ToListAsync();

        public async Task Create(Order order) =>
       await _order.InsertOneAsync(order);
        public async Task CreateP(Order order)
        {
            /*foreach (var admin in order.admin)
            {
                Console.WriteLine(admin.ID);
            }*/
            var json = order.ToJson();
            Console.WriteLine(json);
            var mongoClient = new MongoClient("mongodb+srv://AuthLogin:123@shopdb.40xjquu.mongodb.net/test");
            var session = mongoClient.StartSession();
            var ORDER = session.Client.GetDatabase("Shop").GetCollection<Order>("Order");
            var ITEMS = session.Client.GetDatabase("Shop").GetCollection<Items>("Items");
            var TEMPCART = session.Client.GetDatabase("Shop").GetCollection<Carts>("TempCarts");
            //Begin transaction
            session.StartTransaction();
            try
            {
                foreach (CartItem item in order.items) //update items trong ko
                {
                    var check = ITEMS.Find(m => m.Id == item.ID).FirstOrDefault();
                    check.Remain = check.Remain - item.amount;
                    await ITEMS.UpdateOneAsync(session, m => m.Id == item.ID, Builders<Items>.Update.Set("Remain", check.Remain));
                }

                await ORDER.InsertOneAsync(session, order); // tạo order

                var cart = TEMPCART.Find(m => m.Id == order.buyer).FirstOrDefault();
                cart.items.Clear();
                cart.total = 0;
                await TEMPCART.UpdateOneAsync(session, m => m.Id == order.buyer, Builders<Carts>.Update.Set("items", cart.items).Set("total", cart.total));

                session.CommitTransaction();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception: " + e.Message);
                session.AbortTransaction();
            }
        }
    }



}
