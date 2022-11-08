using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TestAPI.ModelClass;

namespace TestAPI.Data
{
    public class OrderService
    {

        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Admin> _admin;
        public OrderService(IOptions<ShopDbSetting> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _order = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Order>("Order");
        }

        public async Task<List<Order>> Get() =>
           await _order.Find(_ => true).ToListAsync();
        public async Task<Order> GetStatus(string id) =>
          await _order.Find(m => m.Id == id).FirstOrDefaultAsync();
        public async Task<Order> GetOrder(string id) =>
           await _order.Find(m => m.Id == id).FirstOrDefaultAsync();
        public async Task<List<Order>> FindOrder(Order order) =>
           await _order.Find(m => m.buyer == order.buyer).ToListAsync();
        public async Task CountOrder(Response res, string buyer)
        {
            // await _order.DeleteManyAsync(m => m.buyer == buyer);
            var a = await _order.CountDocumentsAsync(m => m.buyer == buyer && m.status == "done");
            res.code = Convert.ToInt32(a);
            double sum = 0;
            List<Order> temp = new List<Order>();
            temp = await _order.Find(m => m.buyer == buyer && m.status == "done").ToListAsync();
            foreach (var order in temp)
            {
                sum += order.total;
            }
            res.msg = Convert.ToString(sum);
        }
        public List<Admin> GetAdmin(string id, List<Admin> admin)
        {
            var mongoClient = new MongoClient("mongodb+srv://AuthLogin:123@shopdb.40xjquu.mongodb.net/test");
            var session = mongoClient.StartSession();
            var ORDER = session.Client.GetDatabase("Shop").GetCollection<Order>("Order");
            var TempOrder = ORDER.Find(m => m.Id == id).FirstOrDefault();
            admin = TempOrder.admins;
            Console.WriteLine(TempOrder.buyer);
            foreach (var temp in admin)
            {
                Console.WriteLine(temp.ID);
            }
            return admin;
        }


        public void DeleteOrderAdmin(string id, Response res)
        {
            try
            {
                _order.DeleteOne(m => m.Id == id);
                res.code = 1;
                res.msg = "success";
            }
            catch (Exception e)
            {
                res.code = 0;
                res.msg = "failed";
            }
        }
        public async Task UpdateOrderAdmin(string id, Order temp, Response res)
        {

            var mongoClient = new MongoClient("mongodb+srv://AuthLogin:123@shopdb.40xjquu.mongodb.net/test");
            var session = mongoClient.StartSession();
            var ORDER = session.Client.GetDatabase("Shop").GetCollection<Order>("Order");
            var ITEMS = session.Client.GetDatabase("Shop").GetCollection<Items>("Items");
            var TempOrder = ORDER.Find(m => m.Id == id).FirstOrDefault();
            session.StartTransaction();

            try
            {
                if (temp.status == "canceled" && TempOrder.status != "canceled")
                {
                    Console.WriteLine("canceled");
                    foreach (var item in TempOrder.items)
                    {
                        var tempItem = ITEMS.Find(m => m.Id == item.ID).FirstOrDefault();
                        tempItem.Remain += item.amount;
                        await ITEMS.ReplaceOneAsync(m => m.Id == item.ID, tempItem);
                    }
                    await ORDER.ReplaceOneAsync(m => m.Id == id, temp);
                }
                else
                {
                    Console.WriteLine("normal");
                    await ORDER.ReplaceOneAsync(m => m.Id == id, temp);
                }
                res.code = 1;
                res.msg = "success";
                session.CommitTransaction();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception: " + e.Message);
                res.code = 2;
                res.msg = "fail";
                session.AbortTransaction();
            }
        }

        public async Task Create(Order order) =>
       await _order.InsertOneAsync(order);
        public async Task UpdateOrder(Response res, string id, Order temp)
        {
            if (temp.payment == "ATM")
            {
                temp.msg = "Chuyển khoản qua số tài khoản momo 0932043965 \nChuyển khoản qua số tài khoản sacombank 0602 0522 7582 \nSố Tiền: " + temp.total + " VND";

            }
            else temp.msg = "Đang xử lý";
            var mongoClient = new MongoClient("mongodb+srv://AuthLogin:123@shopdb.40xjquu.mongodb.net/test");
            var session = mongoClient.StartSession();
            var ORDER = session.Client.GetDatabase("Shop").GetCollection<Order>("Order");
            var ITEMS = session.Client.GetDatabase("Shop").GetCollection<Items>("Items");
            var TempOrder = ORDER.Find(m => m.Id == id).FirstOrDefault();
            session.StartTransaction();
            try
            {
                if (temp.status == "canceled" && TempOrder.status != "canceled")
                {
                    Console.WriteLine("canceled");
                    foreach (var item in TempOrder.items)
                    {
                        var tempItem = ITEMS.Find(m => m.Id == item.ID).FirstOrDefault();
                        tempItem.Remain += item.amount;
                        await ITEMS.ReplaceOneAsync(m => m.Id == item.ID, tempItem);
                    }
                    await ORDER.ReplaceOneAsync(m => m.Id == id, temp);
                }
                else
                {
                    Console.WriteLine("normal");
                    await ORDER.ReplaceOneAsync(m => m.Id == id, temp);
                }
                res.code = 1;
                res.msg = "success";
                session.CommitTransaction();
            }
            catch (Exception e)
            {
                res.code = 0;
                res.msg = e.Message;
                Console.WriteLine("exception: " + e.Message);
                session.AbortTransaction();
            }

        }

        public async Task CreateP(Response res, Order order)
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
                res.code = 1;
                res.msg = "ok";
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

        public async Task CreateOrder(Response res, Order order)
        {
            if (order.payment == "ATM")
            {
                order.msg = "Chuyển khoản qua số tài khoản momo 0932043965 \nChuyển khoản qua số tài khoản sacombank 0602 0522 7582 \nSố Tiền: " + order.total + " VND";

            }
            else order.msg = "Đang xử lý";
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
                res.code = 1;
                res.msg = "ok";
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






    }
}
