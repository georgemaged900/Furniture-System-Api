using System.ComponentModel.DataAnnotations.Schema;

namespace Furniture_System_Api.Models
{
    [Table("Component")]
    public class Component
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public Product Product { get; set; } = null!;
        public ICollection<SubComponent> Subcomponents { get; set; } = new List<SubComponent>();
    }
}
