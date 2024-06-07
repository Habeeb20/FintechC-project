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
                var accountString = account.ToString();
                using StreamWriter writer = new StreamWriter(ApplicationConstants.FileConstants.ACCOUNTFILE, true);
                writer.WriteLine(accountString);
                writer.Flush();
                writer.Close();
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

        public object GetByPin(object pin)
        {
            throw new NotImplementedException();
        }

        public static void LoadInitialAcctData()
        {
            var acctPath = Path.Combine(Directory.GetCurrentDirectory(), ApplicationConstants.FileConstants.ACCOUNTFILE);
            using StreamReader reader = new(acctPath);
            var acct = reader.ReadLine();
            while(acct != null)
            {
                try
                {
                    var acctData= Account.FormatLine(acct);
                    Accounts_DB.Add(acctData);
                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
                acct = reader.ReadLine();
            }
        }
    }
}