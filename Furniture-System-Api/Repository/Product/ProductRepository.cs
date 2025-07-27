using Furniture_System_Api.Configuration.Context;
using Furniture_System_Api.Dtos;
using Furniture_System_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Furniture_System_Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(CreateProductRequestDto createProductRequestDto)
        {
            var product = new Product
            {
                Name = createProductRequestDto.Name,
                Price = createProductRequestDto.Price
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<List<Product>> GetProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int Id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Product?> UpdateProduct(int id, UpdateProductRequestDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return null;

            product.Name = dto.Name;
            product.Price = dto.Price;

            await _context.SaveChangesAsync();
            return product;
        }

        /*        public async Task<List<ProductComponentSubcomponentDto>> GetProductHierarchy()
                {
                    var query = from product in _context.Products
                                join component in _context.Components on product.Id equals component.ProductId
                                join sub in _context.SubComponents on component.Id equals sub.ComponentId
                                select new ProductComponentSubcomponentDto
                                {
                                    ProductId = product.Id,
                                    ProductName = product.Name,
                                    Price = product.Price,

                                    ComponentId = component.Id,
                                    ComponentName = component.Name,
                                    Quantity = component.Quantity,

                                    SubcomponentId = sub.Id,
                                    SubcomponentName = sub.Name,
                                    Material = sub.Material,
                                    CustomNotes = sub.CustomNotes,
                                    Count = sub.Count,
                                    TotalQuantity = sub.TotalQuantity,

                                    DetailLength = sub.DetailLength,
                                    DetailWidth = sub.DetailWidth,
                                    DetailThickness = sub.DetailThickness,

                                    CuttingLength = sub.CuttingLength,
                                    CuttingThickness = sub.CuttingThickness,

                                    FinalLength = sub.FinalLength,
                                    FinalWidth = sub.FinalWidth,
                                    FinalThickness = sub.FinalThickness,

                                    VeneerInner = sub.VeneerInner,
                                    VeneerOuter = sub.VeneerOuter
                                };

                    return await query.ToListAsync();
                }
        */

        public async Task<List<ProductWithComponentsDto>> GetProductHierarchy()
        {
            return await _context.Products
                .Include(p => p.Components)
                    .ThenInclude(c => c.Subcomponents)
                .Select(p => new ProductWithComponentsDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    Price = p.Price,
                    Components = p.Components.Select(c => new ComponentWithSubcomponentsDto
                    {
                        ComponentId = c.Id,
                        ComponentName = c.Name,
                        Quantity = c.Quantity,
                        Subcomponents = c.Subcomponents.Select(s => new SubcomponentDto
                        {
                            SubcomponentId = s.Id,
                            SubcomponentName = s.Name,
                            Material = s.Material,
                            CustomNotes = s.CustomNotes,
                            Count = s.Count,
                            TotalQuantity = s.TotalQuantity,

                            DetailLength = s.DetailLength,
                            DetailWidth = s.DetailWidth,
                            DetailThickness = s.DetailThickness,

                            CuttingLength = s.CuttingLength,
                            CuttingThickness = s.CuttingThickness,

                            FinalLength = s.FinalLength,
                            FinalWidth = s.FinalWidth,
                            FinalThickness = s.FinalThickness,

                            VeneerInner = s.VeneerInner,
                            VeneerOuter = s.VeneerOuter
                        }).ToList()
                    }).ToList()
                }).ToListAsync();
        }
        public async Task <int> AddFullProduct([FromBody] AddFullProductDto dto)
        {
            var product = new Product
            {
                Name = dto.ProductName,
                Price = dto.Price,
                Components = dto.Components.Select(c => new Component
                {
                    Name = c.ComponentName,
                    Quantity = c.Quantity,
                    Subcomponents = c.Subcomponents.Select(s => new SubComponent
                    {
                        Name = s.SubcomponentName,
                        Material = s.Material,
                        CustomNotes = s.CustomNotes,
                        Count = s.Count,
                        TotalQuantity = s.TotalQuantity,
                        DetailLength = s.DetailLength,
                        DetailWidth = s.DetailWidth,
                        DetailThickness = s.DetailThickness,
                        CuttingLength = s.CuttingLength,
                        CuttingThickness = s.CuttingThickness,
                        FinalLength = s.FinalLength,
                        FinalWidth = s.FinalWidth,
                        FinalThickness = s.FinalThickness,
                        VeneerInner = s.VeneerInner,
                        VeneerOuter = s.VeneerOuter
                    }).ToList()
                }).ToList()
            };

            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }
    }
}
