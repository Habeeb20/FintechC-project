using DTO.Command;
using Entity;
using Repository.Abstractions;
using Repository.Implementations;
using Services.Interfaces;

namespace Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly ICustomerRepository customerRepository;
        public AccountService()
        {
            accountRepository = new AccountRepository();
            customerRepository = new CustomerRepository();
        }
        public Account CreateAccount(Guid id, CreateAccountRequest request)
        {
            var customer = customerRepository.GetById(id);
            if (request is not null && customer is not null)
            {
                var account = new Account(request.Pin, request.BankName);
                account.CustomerUserId = customer.Id;
                account.Name = $"{customer.FirstName} {customer.LastName}";
                account.AccountNumber = customer.Phone[1..];
                accountRepository.Add(account);
                return account;
            }
            return null;
        }
        public Account GetAccountBallance(Guid customerId)
        {
            var acct = accountRepository.GetByCustomerId(customerId);
            if (acct is not null)
            {
                return acct;
            }
            return null;
        }
    }
}