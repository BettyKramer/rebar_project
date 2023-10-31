namespace Rebar.dataAcsses


{
    using MongoDB.Driver;
    using Rebar.Models;
    public class DataAcsses
    {
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabeseName = "Rebar";
        private const string MenuCollectionName = "Menu";
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabeseName);
            return db.GetCollection<T>(collection);
        }
        public async Task<List<ShakeModle>> GetAllShake()
        {
            var shaksCollaction = ConnectToMongo<ShakeModle>(MenuCollectionName);
            var result = await shaksCollaction.FindAsync(_ => true);
            return result.ToList();
        }
        public Task CreatSheke(ShakeModle shake)
        {
            var shaksCollaction = ConnectToMongo<ShakeModle>(MenuCollectionName);
            return shaksCollaction.InsertOneAsync(shake);




        }
    }}
    
