using Furniture_System_Api.Dtos;
using Furniture_System_Api.Models;

namespace Furniture_System_Api.Repository
{
    public interface IComponentRepository
    {
        Task<Component> AddComponent(ComponentDto createComponentRequestDto);
        Task<List<Component>> GetComponent();
        Task<Component> GetComponent(int Id);
        Task<Component?> UpdateComponent(int id, CreateComponentDto dto);
        Task<bool> DeleteComponent(int id);
        Task<List<Component>> GetComponentsByProduct(int productId);
    }
}
