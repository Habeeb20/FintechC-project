using DTO.Command;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        bool Register(CreateCustomerRequest request);
    }
}