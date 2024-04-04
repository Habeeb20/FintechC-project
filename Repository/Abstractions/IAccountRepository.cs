using Entity;

namespace Repository.Abstractions
{
    public interface IAccountRepository
    {
        Account GetByPin(int pin);
        bool Add(Account account);
        bool Delete(Account account);
        bool Update(Guid id, Account account);
    }
}