using DTO.Command;
using Entity.Enums;
using Services.Implementations;
using Services.Interfaces;

namespace Menu.Account
{
    public class AccountMenu
    {
        IAccountService accountService;
        public AccountMenu()
        {
            accountService = new AccountService();
        }
        public void CreateAccount(Guid id)
        {
            var account = accountService.GetAccountBallance(id);
            if (account is not null)
            {
                Console.WriteLine($"Account Already created\n" +
                $"Account Name: {account.Name}\t Bank: {account.ToString()}\t Account Number: {account.AccountNumber}");
                return;
            }
            Console.WriteLine("Enter Your Account Pin");
            int pin = int.Parse(Console.ReadLine());
            if (pin.ToString().Length > 4)
            {
                Console.WriteLine("Pin must not be more than 4 digits");
                return;
            }
            Console.WriteLine
            ("1. GTB (Guaranty Trust Bank)\n" +
                  "2. Access Bank\n" +
                  "3. Zenith Bank\n" +
                  "4. First Bank of Nigeria\n" +
                  "5. United Bank for Africa (UBA)\n" +
                  "6. EcoBank Nigeria\n" +
                  "7. Stanbic IBTC Bank\n" +
                  "8. Fidelity Bank Nigeria\n" +
                  "9. Union Bank of Nigeria\n" +
                  "10. Sterling Bank\n" +
                  "11. First City Monument Bank (FCMB)\n" +
                  "12. Wema Bank\n");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input");
                    Console.ResetColor();
                }
                BankName bankName = (BankName)option;
                var request = new CreateAccountRequest
                {
                    Pin = pin,
                    BankName = bankName
                };
            var accountToCreate = accountService.CreateAccount(id, request);
            if (accountToCreate is not null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Account Successfully Created\n"
                + $"Account Name: {accountToCreate.Name}\t Bank: {bankName.ToString()}\t Account Number: {accountToCreate.AccountNumber}");
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Something went wrong, You may need to login again");
        }
        public void CheckAccountBalance(Guid id)
        {
            var account = accountService.GetAccountBallance(id);
            if (account is not null)
                Console.WriteLine($"Your account ballace in {account.BankName.ToString()} is {account.Balance}");
            else
                Console.WriteLine("Something went wrong, You may need to login again");
            return;
        }

    }
}