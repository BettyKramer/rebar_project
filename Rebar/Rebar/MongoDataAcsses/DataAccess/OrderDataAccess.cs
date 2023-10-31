using MongoDataAcsses.Models;
using MongoDB.Driver;
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
        private const string MenuCollectionName = "orders";
        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabeseName);
            return db.GetCollection<T>(collection);
        }
        public List<OrderModel> GetAllOrders()
        {
            var ordersCollaction = ConnectToMongo<OrderModel>(MenuCollectionName);
            var result = ordersCollaction.Find(_ => true);
            return result.ToList();
        }
        public Task CreatOrder(OrderModel order)
        {
            var ordersCollaction = ConnectToMongo<OrderModel>(MenuCollectionName);
            return ordersCollaction.InsertOneAsync(order);
        }
        public Task UpdatShake(OrderModel order)
        {
            var ordersCollaction = ConnectToMongo<OrderModel>(MenuCollectionName);
            var filter = Builders<OrderModel>.Filter.Eq("Name", order.OrderDate);
            return ordersCollaction.ReplaceOneAsync(filter, order, new ReplaceOptions { IsUpsert = true });
        }
        public Task DeleteOrder(OrderModel order)
        {
            var ordersCollaction = ConnectToMongo<OrderModel>(MenuCollectionName);
            return ordersCollaction.DeleteOneAsync(s => order.OrderDate == order.OrderDate);
        }
    }
}
