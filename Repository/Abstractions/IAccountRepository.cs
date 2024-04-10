using Entity;

namespace Repository.Abstractions
{
    public interface IAccountRepository
    {
        Account GetByPin(int pin);
        bool Add(Account account);
        bool Delete(Account account);
        Account GetByCustomerId(Guid id);
        bool Update(Guid id, Account account);
    }
}