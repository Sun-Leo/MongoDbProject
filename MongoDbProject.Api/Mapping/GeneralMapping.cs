using AutoMapper;
using MongoDbProject.Api.DTOS.Category;
using MongoDbProject.Api.DTOS.Product;
using MongoDbProject.Api.Models.Concrete;

namespace MongoDbProject.Api.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
