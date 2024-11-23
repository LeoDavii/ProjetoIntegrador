using Source.Entities;

namespace Source.Interfaces
{
    public interface IOrderService
    {
        Task Create(Order order);
    }
}
