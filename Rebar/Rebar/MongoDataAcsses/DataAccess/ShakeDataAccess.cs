using MongoDataAcsses.Models;
using MongoDB.Driver;

namespace MongoDataAcsses.DataAccess
{
    internal class ShakeDataAccess
    {
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabeseName = "menudb";
        private const string MenuCollectionName = "Menu";
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabeseName);
            return db.GetCollection<T>(collection);
        }
        public async Task<List<ShakeModel>> GetAllShakes()
        {
            var shakesCollaction = ConnectToMongo<ShakeModel>(MenuCollectionName);
            var result = await shakesCollaction.FindAsync(_ => true);
            return result.ToList();
        }
        public Task CreatSheke(ShakeModel shake)
        {
            var shaksCollaction = ConnectToMongo<ShakeModel>(MenuCollectionName);
            return shaksCollaction.InsertOneAsync(shake);
        }
        public Task UpdatShake(ShakeModel shake)
        {
            var shaksCollaction = ConnectToMongo<ShakeModel>(MenuCollectionName);
            var filter=Builders<ShakeModel>.Filter.Eq("Name",shake.Name);
            return shaksCollaction.ReplaceOneAsync(filter,shake,new ReplaceOptions { IsUpsert = true });
        }
        public Task DeleteShake(ShakeModel shake)
        {
            var shaksCollaction = ConnectToMongo<ShakeModel>(MenuCollectionName);
            return shaksCollaction.DeleteOneAsync(s=>s.Name== shake.Name);
        }
    }
}
