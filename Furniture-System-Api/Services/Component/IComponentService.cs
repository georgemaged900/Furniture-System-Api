using Furniture_System_Api.Dtos;

namespace Furniture_System_Api.Services
{
    public interface IComponentService
    {
        Task<ComponentDto> AddComponent(ComponentDto createComponentRequestDto);
        Task<List<ComponentDto>> GetComponent();
        Task<ComponentDto> GetComponent(int Id);
        Task<ComponentDto?> UpdateComponent(int id, CreateComponentDto dto);
        Task<bool> DeleteComponent(int id);
        Task<List<ComponentDto>> GetComponentsByProduct(int productId);
    }
}
