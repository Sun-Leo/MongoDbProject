using MongoDbProject.Api.DTOS.Product;

namespace MongoDbProject.Api.Services.Product
{
    public interface IProductService
    {
        Task<List<Models.Concrete.Product>> GetAllProducts();
        Task CreateProduct(CreateProductDto createProductDto);
        Task DeleteProduct(string id);
        Task UpdateProduct(UpdateProductDto updateProductDto);
    }
}
