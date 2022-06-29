using MongoDB.Driver;
using WebApi.Model;

namespace WebApi.Client
{
    public class MongoDBClient
    {
        MongoClient client;
        IMongoDatabase db;
        public IMongoCollection<MongoDBModel> dbCollection;
        public MongoDBClient()
        {

            try
            {


                client = new MongoClient("mongodb+srv://Compl3x:64287139Dima@waifubotcluster.nmwn1ip.mongodb.net/?retryWrites=true&w=majority");
                db = client.GetDatabase("Favorites");
                dbCollection = db.GetCollection<MongoDBModel>("Favorites");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
