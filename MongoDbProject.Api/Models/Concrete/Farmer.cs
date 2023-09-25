using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbProject.Entities.Concrete
{
    public class Farmer
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string FarmersID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
