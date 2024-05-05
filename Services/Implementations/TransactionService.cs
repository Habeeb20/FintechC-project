using Repository.Abstractions;
using Repository.Implementations;

namespace Services.Implementations
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
        }
    }
}