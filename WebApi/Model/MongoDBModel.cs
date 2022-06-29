using MongoDB.Bson;
namespace WebApi.Model
{
    public class MongoDBModel
    {
        public ObjectId Id { get; set; }


        public string ID { get; set; }

        public string artist { get; set; }

        public string title { get; set; }
    }
}
