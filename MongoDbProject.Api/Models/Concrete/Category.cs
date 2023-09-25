using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbProject.Api.Models.Concrete
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
