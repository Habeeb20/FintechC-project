namespace Menu.Transaction
{
    public class TransactionMenu
    {
        public void CreateTransaction()
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
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
        public void CheckTransactionHistory()
        {

        }
    }
}