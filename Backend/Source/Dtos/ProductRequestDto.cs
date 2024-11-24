namespace Source.Dtos
{
    public struct ProductRequestDto
    {
        public Guid? Id { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
