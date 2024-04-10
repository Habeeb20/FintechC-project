using DTO.Command;
using Entity;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        Account GetAccountBallance(Guid customerId);
        Account CreateAccount(Guid id, CreateAccountRequest request);
    }
}