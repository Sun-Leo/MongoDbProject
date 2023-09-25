using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbProject.Api.Models.Concrete
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string CategoryID { get; set; }
        public Category Category { get; set; }


    }
}
