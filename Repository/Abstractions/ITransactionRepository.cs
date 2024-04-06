
using Entity;

namespace Repository.Abstractions
{
    public interface ITransactionRepository
    {
          bool Add(Transaction transaction);

         List<Transaction> GetAll(int pin);

         List<Transaction> GetByDate(int pin, DateTime transactionDate);
         
    }
}