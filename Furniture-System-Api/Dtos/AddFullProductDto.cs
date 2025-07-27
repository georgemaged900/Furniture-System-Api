namespace Furniture_System_Api.Dtos
{
    public class AddFullProductSubcomponentDto
    {
        public string SubcomponentName { get; set; }
        public string Material { get; set; }
        public string CustomNotes { get; set; }
        public int Count { get; set; }
        public int TotalQuantity { get; set; }
        public decimal DetailLength { get; set; }
        public decimal DetailWidth { get; set; }
        public decimal DetailThickness { get; set; }
        public decimal CuttingLength { get; set; }
        public decimal CuttingThickness { get; set; }
        public decimal FinalLength { get; set; }
        public decimal FinalWidth { get; set; }
        public decimal FinalThickness { get; set; }
        public string VeneerInner { get; set; }
        public string VeneerOuter { get; set; }
    }

    public class AddFullProductComponentDto
    {
        public string ComponentName { get; set; }
        public int Quantity { get; set; }
        public List<AddFullProductSubcomponentDto> Subcomponents { get; set; }
    }

    public class AddFullProductDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public List<AddFullProductComponentDto> Components { get; set; }
    }

}
