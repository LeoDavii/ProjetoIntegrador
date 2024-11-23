namespace Source.Entities
{
    public class Product : BaseEntity
    {
        public double Value { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string ImageUrl { get; protected set; }

        public Product(double value, 
                       string name, 
                       string description, 
                       string imageUrl) : base()
        {
            Value = value;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }

        public void Update(double value,
                           string name,
                           string description,
                           string imageUrl)
        {
            Value = value;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
