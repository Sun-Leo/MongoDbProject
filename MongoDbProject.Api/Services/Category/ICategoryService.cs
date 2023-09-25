using MongoDbProject.Api.DTOS.Category;

namespace MongoDbProject.Api.Services.Category
{
    public interface ICategoryService
    {
        Task<List<Models.Concrete.Category>> GetAllCategories();
        Task CreateCategory(CreateCategoryDto createCategoryDto);
        Task DeleteCategory(string id);
        Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
    }
}
