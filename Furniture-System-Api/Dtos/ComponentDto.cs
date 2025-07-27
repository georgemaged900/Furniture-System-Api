namespace Furniture_System_Api.Dtos
{
    public class ComponentDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateComponentDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }


    public class ProductComponentSubcomponentDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int ComponentId { get; set; }
        public string ComponentName { get; set; }
        public int Quantity { get; set; }

        public int SubcomponentId { get; set; }
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


    public class SubcomponentDto
    {
        public int SubcomponentId { get; set; }
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

    public class ComponentWithSubcomponentsDto
    {
        public int ComponentId { get; set; }
        public string ComponentName { get; set; }
        public int Quantity { get; set; }
        public List<SubcomponentDto> Subcomponents { get; set; }
    }

    public class ProductWithComponentsDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public List<ComponentWithSubcomponentsDto> Components { get; set; }
    }




}
