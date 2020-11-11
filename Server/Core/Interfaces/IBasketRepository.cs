using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetCustomerBasketAsync(string basketId);

        Task<CustomerBasket> CreateOrUpdateCustomerBasketAsync(CustomerBasket customerBasket);

        Task<bool> DeleteCustomerBasketAsync(string basketId);
    }
}
