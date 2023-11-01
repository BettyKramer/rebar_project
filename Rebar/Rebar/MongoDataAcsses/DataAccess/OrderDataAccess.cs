using MongoDataAcsses.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataAcsses.DataAccess
{
    public class OrderDataAccess
    {

        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabeseName = "Ordersdb";
        private const string OrderCollection = "orders";
        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabeseName);
            return db.GetCollection<T>(collection);
        }
        public List<OrderModel> GetAllOrders()
        {
            var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);
            var result = ordersCollection.Find(_ => true);
            return result.ToList();
        }
        public Task CreatOrder(OrderModel order)
        {
            var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);
            return ordersCollection.InsertOneAsync(order);
        }
        public Task UpdatShake(OrderModel order)
        {
            var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);
            var filter = Builders<OrderModel>.Filter.Eq("Name", order.startOrder);
            return ordersCollection.ReplaceOneAsync(filter, order, new ReplaceOptions { IsUpsert = true });
        }
        public Task DeleteOrder(OrderModel order)
        {
            var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);
            return ordersCollection.DeleteOneAsync(s => order.startOrder == order.startOrder);
        }
        //public bool isSizeVlide(Guid shakeId)
        //{
        //    var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);
        //    List<ShakeOrder> shakes = ordersCollection.Aggregate().Match(s => s.shakes == shakeId).FirstOrDefaultAsync();


        //    {
        //        if (!shake.size.Equals("M") || !shake.size.Equals("L") || !shake.size.Equals("S"))
        //            return false;
        //    }
        //    return true;
        //}
        public bool IsNameValied(string name)
        {
            if(string.IsNullOrEmpty(name)) return false;
            else if(name.ToList().Count>20|| name.ToList().Count<3) return false;
            return true;
        }
    }
}
