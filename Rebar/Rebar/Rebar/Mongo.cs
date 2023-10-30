using MongoDB.Bson;
using MongoDB.Driver;

namespace Rebar
{
    public class Mongo
    {
        var conString = "mongodb://localhost:27017";
        var Client = new MongoClient(conString);
        var DB = Client.GetDatabase("test");
        var collection = DB.GetCollection<bsondocument>("test");

        
    //    string connectionString = "mongodb://127.0.0.1:27017";
    //    string databaseName = "reber_db";

    //    var client = new MongoClient(connectionString);
    //    var db = client.GetDatabase(databaseName);
    }
}
