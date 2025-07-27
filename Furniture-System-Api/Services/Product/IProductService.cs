using Furniture_System_Api.Dtos;
using Furniture_System_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Furniture_System_Api.Services.ProductService
{
    public interface IProductService
    {
        Task<CreateProductResponseDto> AddProduct(CreateProductRequestDto createProductRequestDto);
        Task<List<ProductDto>> GetProduct();
        Task<ProductDto> GetProduct(int Id);
        Task<ProductDto?> UpdateProduct(int id, UpdateProductRequestDto dto);
        Task<bool> DeleteProduct(int id);
        Task<List<ProductWithComponentsDto>> GetProductHierarchy();
        Task <int> AddFullProduct(AddFullProductDto dto);
    }
}
