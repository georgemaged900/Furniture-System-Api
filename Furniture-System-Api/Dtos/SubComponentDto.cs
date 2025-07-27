namespace Furniture_System_Api.Dtos
{
    public class SubComponentDto
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string CustomNotes { get; set; }
        public int Count { get; set; }
        public int TotalQuantity { get; set; }
        public double DetailLength { get; set; }
        public double DetailWidth { get; set; }
        public double DetailThickness { get; set; }
        public double CuttingLength { get; set; }
        public double CuttingWidth { get; set; }
        public double CuttingThickness { get; set; }
        public double FinalLength { get; set; }
        public double FinalWidth { get; set; }
        public double FinalThickness { get; set; }
        public string VeneerInner { get; set; }
        public string VeneerOuter { get; set; }
    }
    public class CreateSubcomponentDto
    {
        public int ComponentId { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string CustomNotes { get; set; }
        public int Count { get; set; }
        public int TotalQuantity { get; set; }
        public double DetailLength { get; set; }
        public double DetailWidth { get; set; }
        public double DetailThickness { get; set; }
        public double CuttingLength { get; set; }
        public double CuttingWidth { get; set; }
        public double CuttingThickness { get; set; }
        public double FinalLength { get; set; }
        public double FinalWidth { get; set; }
        public double FinalThickness { get; set; }
        public string VeneerInner { get; set; }
        public string VeneerOuter { get; set; }
    }
}
