using Source.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Source.Entities
{
    public class Order : BaseEntity
    {
        public double TotalValue { get; protected set; }
        public IEnumerable<ProductDto> Products { get; protected set; }
        public AddressDto Address { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        [ForeignKey("User")]
        public Guid UserId { get; protected set; }

        public Order(Guid userId, 
                     IEnumerable<ProductDto> products,
                     AddressDto address) : base() 
        {
            UserId = userId;
            Products = products;
            Address = address;
            CreatedAt = DateTime.Now;
        }
    }
}
