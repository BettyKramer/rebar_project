using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAcsses.Models
{
    public class OrderModel
    {
        Guid Id { get; set; }= Guid.NewGuid();
        public List<Guid> shakes { get; set; }
        public string CustomerName { get; set; }
        public DateTime startOrder { get; set; }
        public DateTime endOrder { get; set; }
        public int SumPrices { get; set; }
        public List<SaleModel> sales { get; set; }

        public OrderModel(List<Guid> shakes,string customer,int sum,DateTime start,DateTime end)
        {
            this.shakes = shakes;
            this.CustomerName = customer;
            this.SumPrices = sum;
            this.startOrder = start;
            this.endOrder = end;
        }
        public OrderModel() { } 
    }
}
