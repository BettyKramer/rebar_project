using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAcsses.Models
{
    public class OrderModel
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        Guid Id { get; set; }
        public List<ShakeOrder> shakes { get; set; }
        public string CustomerName { get; set; }
        public DateTime startOrder { get; set; }
        public DateTime endOrder { get; set; }
        public int SumPrices { get; set; }
        public List<SaleModel> sales { get; set; }
    }
}
