using DTO.Command;
using Entity;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        bool Register(CreateCustomerRequest request);
        Customer GetCustomer(string phone, string password);
    }
}