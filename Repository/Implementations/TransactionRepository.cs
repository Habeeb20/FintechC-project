using Entity;

namespace Repository.Implementations
{
    public class TransactionRepository
    {
        private readonly List<Transaction> Transactions_DB;
        public TransactionRepository()
        {
            Transactions_DB  = [];   
        }
        // CRUD
        public bool Add(Transaction transaction)
        {
            if (transaction is not null)
            {
                Transactions_DB.Add(transaction);
                return true;
            }
            return false;
        }
        public List<Transaction> GetAll(int pin)
        {
            // var transactions = Transactions_DB
            // .Where(x => x.Pin == pin).ToList();

            // var transactions = from x in Transactions_DB 
            // where x.Pin == pin select x;

            List<Transaction> transactions = [];
            foreach (var transaction in transactions)
            {
                if (transaction.Pin == pin)
                {
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }
        public List<Transaction> GetByDate(int pin, DateTime transactionDate)
        {
            var transactions = Transactions_DB
            .FindAll(t => t.Pin == pin && t.TransactionDate.Date >= transactionDate);
            return transactions;
        }
        
    }
}