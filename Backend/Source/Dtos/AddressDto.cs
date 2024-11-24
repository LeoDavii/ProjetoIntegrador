namespace Source.Dtos
{
    public class AddressDto
    {
        public string Description { get; set; }
        public string Zipcode { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public AddressDto() { }
        public AddressDto(string zipCode, 
                          string street, 
                          int? number, 
                          string neighborhood, 
                          string complement, 
                          string city, 
                          string state)
        {
            Zipcode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            City = city;
            State = state;
        }
    }
}
