using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Furniture_System_Api.Models
{
    [Table("SubComponent")]
    public class SubComponent
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string CustomNotes { get; set; } = string.Empty;
        public int Count { get; set; }
        public int TotalQuantity { get; set; }
        public decimal DetailLength { get; set; }
        public decimal DetailWidth { get; set; }
        public decimal DetailThickness { get; set; }
        public decimal CuttingLength { get; set; }
        public decimal CuttingWidth { get; set; }
        public decimal CuttingThickness { get; set; }
        public decimal FinalLength { get; set; }
        public decimal FinalWidth { get; set; }
        public decimal FinalThickness { get; set; }
        public string VeneerInner { get; set; } = string.Empty;
        public string VeneerOuter { get; set; } = string.Empty;
        public Component? Component { get; set; }
    }
}
