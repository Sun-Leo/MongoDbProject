using AutoMapper;
using MongoDB.Driver;
using MongoDbProject.Api.DTOS.Category;
using MongoDbProject.Api.DTOS.Product;
using MongoDbProject.Api.Models.Concrete;
using MongoDbProject.Api.Settings;

namespace MongoDbProject.Api.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Models.Concrete.Category> _categoryCollection;
        private readonly IMapper _mapper;


        public CategoryService(IDataBaseSettings _dataBaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _categoryCollection = dataBase.GetCollection<Models.Concrete.Category>(_dataBaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Models.Concrete.Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
            
        }

        public async Task DeleteCategory(string id)
        {
            await _categoryCollection.DeleteOneAsync(x=>x.CategoryID == id);
        }

        public async Task<List<Models.Concrete.Category>> GetAllCategories()
        {
            var value= await _categoryCollection.Find(x=>true).ToListAsync();
            return value;
        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Models.Concrete.Category>(updateCategoryDto);

            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, value);
        }
    }
}
