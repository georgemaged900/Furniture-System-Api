namespace Furniture_System_Api.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class CreateProductRequestDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class CreateProductResponseDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateProductRequestDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class UpdateProductResponseDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }


}
