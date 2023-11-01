using MongoDataAcsses.Models;
using MongoDB.Bson;
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
        public IMongoCollection<BsonDocument> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabeseName);
            return db.GetCollection <BsonDocument> (collection);
        }
        //public BsonDocument <OrderModel> GetAllOrders()
        //{
        //    var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);
    
        //    return ordersCollection;
        //}
        public int GetNumberOfOrders()
        {
            var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);

            var count = ordersCollection.CountDocuments(Builders<BsonDocument>.Filter.Empty);

            return Convert.ToInt32(count);
        }
        public Task CreatOrder(OrderModel order)
        {
            var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);

            return ordersCollection.InsertOne(order);
        }
        public Task DeleteOrder(OrderModel order)
        {
            var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);
            return ordersCollection.DeleteOneAsync(s => order.startOrder == order.startOrder);
        }
        public bool isSizeVlide(Guid shakeId)
        {
            var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);

            var filter = Builders<BsonDocument>.Filter.Regex("Id", new BsonRegularExpression(shakeId.ToString()));

            foreach (var order in ordersCollection.Find(filter).ToListAsync().Result)
            {
               char size = (char)order["size"];

                if (!size.Equals('S') || !size.Equals('M') || !size.Equals('L'))
                    return false;

            }//end foreach
            return true;
        }
        public bool IsNameValied(string name)
        {
            if(string.IsNullOrEmpty(name)) return false;
            else if(name.ToList().Count>20|| name.ToList().Count<3) return false;
            return true;
        }
        //public int GetSumOfPrices(Guid id)
        //{
        //    var ordersCollection = ConnectToMongo<OrderModel>(OrderCollection);
        //    int sum=ordersCollection.
        //}
    }
}
