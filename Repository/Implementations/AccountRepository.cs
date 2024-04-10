using Entity;
using Repository.Abstractions;

namespace Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly static List<Account> Accounts_DB = [];
        public AccountRepository()
        {
        }
        // CRUD
        public bool Add(Account account)
        {
            if (account is not null)
            {
                Accounts_DB.Add(account);
                return true;
            }
            return false;
        }
        public Account GetByCustomerId(Guid id)
        {
            foreach (var account in Accounts_DB)
            {
                if (account.CustomerUserId == id)
                {
                    return account;
                }
            }
            return null;
        }
        public Account GetByPin(int pin)
        {
            foreach (var account in Accounts_DB)
            {
                if (account.Pin == pin)
                {
                    return account;
                }
            }
            return null;
        }
        public bool Update(Guid id, Account account)
        {
            var acct = (from x in Accounts_DB where x.Id == id select x).SingleOrDefault();
            if (acct is not null)
            {
                Accounts_DB.Remove(acct);
                return true;
            }
            return false;
        }
        public bool Delete(Account account)
        {
            if (account is not null)
            {
                Accounts_DB.Remove(account);
                return true;
            }
            return false;
        }
    }
}