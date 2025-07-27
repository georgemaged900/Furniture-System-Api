using Furniture_System_Api.Dtos;
using Furniture_System_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furniture_System_Api.Repository
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(CreateProductRequestDto createProductRequestDto);
        Task<List<Product>> GetProduct();
        Task<Product> GetProduct(int Id);
        Task<Product?> UpdateProduct(int id, UpdateProductRequestDto updatedProduct);
        Task<bool> DeleteProduct(int id);
        //Task<List<ProductComponentSubcomponentDto>> GetProductHierarchy();//
        Task<List<ProductWithComponentsDto>> GetProductHierarchy();
        Task <int> AddFullProduct(AddFullProductDto dto);

    }
}
