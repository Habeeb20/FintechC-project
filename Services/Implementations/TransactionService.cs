using DTO.Command;
using DTO.Query;
using Repository.Abstractions;
using Repository.Implementations;
using Entity;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService()
        {
            _customerRepository = new CustomerRepository();
            _accountRepository = new AccountRepository();
            _transactionRepository = new TransactionRepository();
        }
        public (TransactionDto, string) Create(CreateTransactionRequest request, Guid customerId)
        {
            if (request is null)
            {
                return (null, "Enter all required field");
            }
            var customer = _customerRepository.GetById(customerId);
            var account = _accountRepository.GetByPin(request.Pin);
            if (account?.CustomerUserId == customer.Id)
            {
                if (account.Balance < request.Amount)
                {
                    return (null, "Insufficient Balance");
                }
                var transaction = new Transaction()
                {
                    AccountId = account.Id,
                    Amount = request.Amount,
                    Description = request.Description,
                    TransactionType = request.TransactionType,
                    ReceiverAcctNum = request.ReceiverAcctNum ?? nameof(request.TransactionType),
                };
                _transactionRepository.Add(transaction);
                account.Balance -= transaction.Amount;
                return (new TransactionDto
                {
                    Amount = transaction.Amount,
                    Description = transaction.Description,
                    TransactionType = transaction.TransactionType,
                    ReceiverAcctNum = transaction.ReceiverAcctNum
                }, "Transaction successful");
            }
            return (null, "Invalid Pin");
        }
        public List<TransactionDto> GetAll(Guid customerId)
        {
            var account = _accountRepository.GetByCustomerId(customerId);
            if (account is not null)
            {
                Console.WriteLine(account.AccountNumber);
                var transactions = _transactionRepository.GetAll(account.Id);
                Console.WriteLine(transactions.Count);
                return transactions.Select(x => new TransactionDto
                {
                    Amount = x.Amount,
                    TransactionDate = x.TransactionDate,
                    TransactionType = x.TransactionType,
                    ReceiverAcctNum = x.ReceiverAcctNum,
                    Description = x.Description
                }).ToList();
            }
            return [];
        }

    }
}