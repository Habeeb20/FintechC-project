using Entity;
using Repository.Abstractions;

namespace Repository.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private static readonly List<Transaction> Transactions_DB = [];
        // public TransactionRepository()
        // {
        //     Transactions_DB  = [];   
        // }
        // CRUD
        public bool Add(Transaction transaction)
        {
            if (transaction is not null)
            {
                var transact = transaction.ToString();
                using StreamWriter writer = new StreamWriter(ApplicationConstants.FileConstants.TRANSACTION, true);
                writer.WriteLine();
                writer.Flush();
                writer.Close();
                return true;
            }
            return false;
        }
        public List<Transaction> GetAll(Guid accountId)
        {
            // var transactions = Transactions_DB
            // .Where(x => x.Pin == pin).ToList();

            // var transactions = from x in Transactions_DB 
            // where x.Pin == pin select x;

            List<Transaction> transactions = [];
            foreach (var transaction in transactions)
            {
                if (transaction.AccountId == accountId)
                {
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }
        public List<Transaction> GetByDate(Guid accountId, DateTime transactionDate)
        {
            var transactions = Transactions_DB
            .FindAll(t => t.AccountId == accountId && t.TransactionDate.Date >= transactionDate);
            return transactions;
        }

        public static void LoadInitialTransactionData()
        {
            var transactPath = Path.Combine(Directory.GetCurrentDirectory(), ApplicationConstants.FileConstants.TRANSACTION);
            using StreamReader reader = new(transactPath);
            var transactionData = reader.ReadLine();

            while( transactionData != null)
            {
                try
                {
                    var dataReader = Transaction.FormatLine(transactionData);
                    Transactions_DB.Add(dataReader);
                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }

                transactionData = reader.ReadLine();
              
                
                

            }
        }
        
    }
}