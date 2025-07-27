using FL.Application.Exception;
using Furniture_System_Api.Dtos;
using Furniture_System_Api.Repository;

namespace Furniture_System_Api.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _componentRepository;

        public ComponentService(IComponentRepository componentRepository)
        {
            _componentRepository = componentRepository;
        }

        public async Task<ComponentDto> AddComponent(ComponentDto createComponentRequestDto)
        {
            try
            {
                var component = await _componentRepository.AddComponent(createComponentRequestDto);

                return new ComponentDto
                {
                    Id = component.Id,
                    ProductId = component.ProductId,
                    Name = component.Name,
                    Quantity = component.Quantity
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteComponent(int id)
        {
            var result = await _componentRepository.DeleteComponent(id);
            if (!result)
                throw new NotFoundException("Component not Found",id);
            return result;
        }

        public async Task<List<ComponentDto>> GetComponent()
        {
            var components = await _componentRepository.GetComponent();

            return components.Select(c => new ComponentDto
            {
                Id = c.Id,
                ProductId = c.ProductId,
                Name = c.Name,
                Quantity = c.Quantity
            }).ToList();
        }

        public async Task<ComponentDto> GetComponent(int id)
        {
            var component = await _componentRepository.GetComponent(id);
            if (component == null) throw new NotFoundException("Component Id not Found", id);

            return new ComponentDto
            {
                Id = component.Id,
                ProductId = component.ProductId,
                Name = component.Name,
                Quantity = component.Quantity
            };
        }

        public async Task<List<ComponentDto>> GetComponentsByProduct(int productId)
        {
            var components = await _componentRepository.GetComponentsByProduct(productId);

            return components.Select(c => new ComponentDto
            {
                Id = c.Id,
                ProductId = c.ProductId,
                Name = c.Name,
                Quantity = c.Quantity
            }).ToList();
        }

        public async Task<ComponentDto?> UpdateComponent(int id, CreateComponentDto dto)
        {
            var updated = await _componentRepository.UpdateComponent(id, dto);
            if (updated == null) throw new NotFoundException("Component Id not Found", id);

            return new ComponentDto
            {
                Id = updated.Id,
                ProductId = updated.ProductId,
                Name = updated.Name,
                Quantity = updated.Quantity
            };
        }
    }
}
