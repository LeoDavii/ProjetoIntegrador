namespace Source.Dtos
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public double Value { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
