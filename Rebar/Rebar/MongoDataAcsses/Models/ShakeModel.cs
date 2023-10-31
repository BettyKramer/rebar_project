using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAcsses.Models
{
    public class ShakeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriceS { get; set; }
        public int PriceM { get; set; }
        public int PriceL { get; set; }

        public ShakeModel(string name, string description, int priceS, int priceM, int priceL)
        {
            this.Name = name;
            this.Description = description;
            this.PriceS = priceS;
            this.PriceM = priceM;
            this.PriceL = priceL;
        }
    }
}
