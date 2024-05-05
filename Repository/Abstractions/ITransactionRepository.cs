
using Entity;

namespace Repository.Abstractions
{
    public interface ITransactionRepository
    {
        bool Add(Transaction transaction);
        List<Transaction> GetAll(Guid accountId);
        List<Transaction> GetByDate(Guid accountId, DateTime transactionDate);
    }
}