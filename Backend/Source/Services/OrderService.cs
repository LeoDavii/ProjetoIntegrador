using Source.Entities;
using Source.Interfaces;

namespace Source.Services
{
    public class OrderService(IOrderRepository orderRepository, IUserService userService) : IOrderService
    {
        public async Task Create(Order order)
        {
            await ValidateOrder(order);
            await ValidateUser(order);

            orderRepository.Create(order);
            await orderRepository.CommitAsync();
        }

        private Task ValidateOrder(Order order)
        {
            throw new NotSupportedException();
        }

        private Task ValidateUser(Order order)
        {
            throw new NotSupportedException();
        }
    }
}
