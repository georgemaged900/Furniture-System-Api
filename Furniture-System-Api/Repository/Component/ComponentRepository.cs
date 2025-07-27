using Furniture_System_Api.Configuration.Context;
using Furniture_System_Api.Dtos;
using Furniture_System_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Furniture_System_Api.Repository
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly ApplicationDbContext _context;

        public ComponentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Component> AddComponent(ComponentDto createComponentRequestDto)
        {
            var component = new Component
            {
                ProductId = createComponentRequestDto.ProductId,
                Name = createComponentRequestDto.Name,
                Quantity = createComponentRequestDto.Quantity
            };

            await _context.Components.AddAsync(component);
            await _context.SaveChangesAsync();

            return component;
        }

        public async Task<bool> DeleteComponent(int id)
        {
            var component = await _context.Components.FindAsync(id);
            if (component == null)
                return false;

            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Component>> GetComponent()
        {
            return await _context.Components.ToListAsync();
        }

        public async Task<Component> GetComponent(int Id)
        {
            return await _context.Components.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Component>> GetComponentsByProduct(int productId)
        {
            return await _context.Components
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }

        public async Task<Component?> UpdateComponent(int id, CreateComponentDto dto)
        {
            var component = await _context.Components.FirstOrDefaultAsync(c => c.Id == id);
            if (component == null)
                return null;

            component.Name = dto.Name;
            component.Quantity = dto.Quantity;
            component.ProductId = dto.ProductId;

            _context.Components.Update(component);
            await _context.SaveChangesAsync();

            return component;
        }

    }
}
