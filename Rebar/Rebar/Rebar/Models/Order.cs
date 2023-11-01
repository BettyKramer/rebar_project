using MongoDB.Bson;

namespace Rebar.Models
{
    public class Order
    {
        public List<Shake> shakes { get; set; }
        Guid Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public int SumPrices { get; set; }
        public List<Sale> sales { get; set; }
    }
}
