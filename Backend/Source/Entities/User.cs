using Source.Dtos;
using Source.Enum;

namespace Source.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected  set; }
        public IEnumerable<AddressDto>? Adresses { get; protected set; } 
        public UserRole Role { get; protected set; }

        public User(string name, 
                    string email, 
                    string password, 
                    IEnumerable<AddressDto> adresses,
                    UserRole role) : base() 
        { 
            Name = name;
            Email = email;
            Password = password;
            Adresses = adresses;
            Role = role;
        }
    }
}
