using AutoMapper;
using MongoDB.Driver;
using MongoDbProject.Api.DTOS.Product;
using MongoDbProject.Api.Settings;

namespace MongoDbProject.Api.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Models.Concrete.Product> _productsCollection;
        private readonly IMapper _mapper;

        public ProductService(IDataBaseSettings _dataBaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _productsCollection = dataBase.GetCollection<Models.Concrete.Product>(_dataBaseSettings.ProductCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Models.Concrete.Product>(createProductDto);

            await _productsCollection.InsertOneAsync(value);
        }

        public async Task DeleteProduct(string id)
        {
            await _productsCollection.DeleteOneAsync(x=>x.ProductID == id);
        }

        public async Task<List<Models.Concrete.Product>> GetAllProducts()
        {
           var value= await _productsCollection.Find(x=>true).ToListAsync();
            return value;
        }

        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Models.Concrete.Product>(updateProductDto);

            await _productsCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, value);
                
        }

       
    }
}
