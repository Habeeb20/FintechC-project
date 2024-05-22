using DTO.Command;
using Entity;
using Entity.Enums;
using Services.Implementations;
using Services.Interfaces;

namespace Menu.Transaction
{
    public class TransactionMenu
    {
        ITransactionService _transactionService;
        public TransactionMenu()
        {
            _transactionService = new TransactionService();
        }
        public void CreateTransaction(Guid customerId)
        {
            Console.WriteLine(
                "1. Airtime\n2. Data\n3. Transfer\n4. Deposit"
                );
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid Input");
            }
            switch (option)
            {
                case 1:
                    CreateAirTimeTransaction(customerId);
                    break;
                case 2:
                    CreateDataTransaction(customerId);
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
        public void CreateAirTimeTransaction(Guid customerId)
        {
            Console.WriteLine("1. N100\n2. N200\n3. N500\n4. N1000\n5. N2000");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
            }
            var transactionRequest = new CreateTransactionRequest()
            {
                TransactionType = TransactionType.AirTime
            };
            switch (option)
            {
                case 1:
                    transactionRequest.Amount = 100;
                    break;
                case 2:
                    transactionRequest.Amount = 200;
                    break;
                case 3:
                    transactionRequest.Amount = 500;
                    break;
                case 4:
                    transactionRequest.Amount = 1000;
                    break;
                case 5:
                    transactionRequest.Amount = 2000;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Pin Required");
            int pin = int.Parse(Console.ReadLine());
            transactionRequest.Pin = pin;
            var transaction = _transactionService.Create(transactionRequest, customerId);
            Console.WriteLine(transaction.Item2);
        }
        public void CreateDataTransaction(Guid customerId)
        {
            Console.WriteLine("1. N50 for 25MB\n2. N100 for 75MB\n3. N200 for 200MB\n4. N500 for 750MB\n5. N1000 for 1.5GB\n6. N2000 for 3.5GB");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
            }
            var transactionRequest = new CreateTransactionRequest()
            {
                TransactionType = TransactionType.Data
            };
            switch (option)
            {
                case 1:
                    transactionRequest.Amount = 25;
                    break;
                case 2:
                    transactionRequest.Amount = 75;
                    break;
                case 3:
                    transactionRequest.Amount = 200;
                    break;
                case 4:
                    transactionRequest.Amount = 750;
                    break;
                case 5:
                    transactionRequest.Amount = 1.5M;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Pin Required");
            int pin = int.Parse(Console.ReadLine());
            transactionRequest.Pin = pin;
            var transaction = _transactionService.Create(transactionRequest, customerId);
            Console.WriteLine(transaction.Item2);
        }
        public void CreateTransferTransaction(Guid customerId)
        {
            Console.WriteLine("Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Receiver Account:");
            string receiverAcctNum = Console.ReadLine();
            Console.WriteLine("Transaction Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Pin Required");
            int pin = int.Parse(Console.ReadLine());
            var transaction = new CreateTransactionRequest()
            {
                Pin = pin,
                Amount = amount,
                Description = description,
                ReceiverAcctNum = receiverAcctNum,
                TransactionType = TransactionType.Trasnfer
            };
            var transact = _transactionService.Create(transaction, customerId);
            Console.WriteLine(transact.Item2);
        }
        public void CheckTransactionHistory(Guid customerId)
        {
            var transactions = _transactionService.GetAll(customerId);
            Console.WriteLine("_____________Transaction History________________");
            if (transactions.Count != 0)
            {
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"\nAmount: {transaction.Amount}");
                    Console.WriteLine($"\nTransaction Type: {transaction.TransactionType.ToString()}");
                    Console.WriteLine($"\nTransaction Date: {transaction.TransactionDate}");
                    Console.WriteLine($"\nDescription: {transaction.Description}");
                    Console.WriteLine($"\nReceiver: {transaction.ReceiverAcctNum}");
                }
            }
            Console.WriteLine("________________________________________________");
        }
    }
}