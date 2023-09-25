using MongoDbProject.Api.Models.Concrete;

namespace MongoDbProject.Api.DTOS.Product
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string CategoryID { get; set; }
    }
}
