using Menu.Account;
using Menu.Transaction;
using Services.Implementations;
using Services.Interfaces;

namespace Menu.Customer
{
    public class CustomerLogin
    {
        TransactionMenu _transactionMenu;
        AccountMenu _accountMenu;
        ICustomerService _customerService;
        public CustomerLogin()
        {
            _accountMenu = new AccountMenu();
            _transactionMenu = new TransactionMenu();
            _customerService = new CustomerService();
        }
        public void LoginMenu()
        {
            Entity.Customer customer = null;
            while (customer is null)
            {
                System.Console.WriteLine("###Login###");
                Console.ResetColor();
                Console.WriteLine("Enter Phone number");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter your password");
                string pass = Console.ReadLine();
                customer = _customerService.GetCustomer(phone, pass);
                if (customer is null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inavlid login details");
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Login Successfull");
            CustomerSubMenu(customer.Id);
        }
        public void CustomerSubMenu(Guid id)
        {
            Console.ResetColor();
            Console.WriteLine(
                "1. Create Account\n2. Check Balance\n3. New Transaction\n4. Transaction History"
                );
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
            }
            switch (option)
            {
                case 1:
                    _accountMenu.CreateAccount(id);
                    CustomerSubMenu(id);
                    break;
                case 2:
                    _accountMenu.CheckAccountBalance(id);
                    CustomerSubMenu(id);
                    break;
                case 3:
                    _transactionMenu.CreateTransaction();
                    break;
                case 4:
                    _transactionMenu.CheckTransactionHistory();
                    break;
                default:
                    break;
            }
        }
    }
}