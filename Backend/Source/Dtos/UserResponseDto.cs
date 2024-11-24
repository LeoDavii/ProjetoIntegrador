using Source.Enum;

namespace Source.Dtos
{
    public struct UserLoginResponseDto
    {
        public string Token { get; set; }
        public IEnumerable<AddressDto>? Addresses { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
    }
}
