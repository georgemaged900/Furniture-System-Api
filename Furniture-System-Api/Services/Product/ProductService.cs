using FL.Application.Exception;
using Furniture_System_Api.Dtos;
using Furniture_System_Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Furniture_System_Api.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductResponseDto> AddProduct(CreateProductRequestDto createProductRequestDto)
        {
            var result = await _productRepository.AddProduct(createProductRequestDto);
            return new CreateProductResponseDto() { Name = result.Name, Price = result.Price };// can use automapper better
        }

        public async Task<List<ProductDto>> GetProduct()
        {
            var products = await _productRepository.GetProduct();

            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
            return productDtos;
        }

        public async Task<ProductDto?> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
                throw new NotFoundException("Product Id not Found", id);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var result =  await _productRepository.DeleteProduct(id);
            if(!result)
                throw new NotFoundException("Product Id not Found", id);
            return result;
        }

        public async Task<ProductDto?> UpdateProduct(int id, UpdateProductRequestDto dto)
        {
            var result = await _productRepository.UpdateProduct(id, dto);
            if (result == null)
                return null;

            return new ProductDto
            {
                Id = result.Id,
                Name = result.Name,
                Price = result.Price
            };
        }
        public async Task<List<ProductWithComponentsDto>> GetProductHierarchy()
        {
            return await _productRepository.GetProductHierarchy();
        }
        public async Task <int> AddFullProduct(AddFullProductDto dto)
        {
            return await _productRepository.AddFullProduct(dto);
        }
    }
}
