using Menu;
using Repository.Implementations;

internal class Program
{
    private static void Main(string[] args)
    {
        if(!File.Exists(ApplicationConstants.FileConstants.CUSTOMERFILE))
        {
            File.Create(Path.Combine(Directory.GetCurrentDirectory(),ApplicationConstants.FileConstants.CUSTOMERFILE));
        }

        if(!File.Exists(ApplicationConstants.FileConstants.ACCOUNTFILE))
        {
            File.Create(Path.Combine(Directory.GetCurrentDirectory(),ApplicationConstants.FileConstants.ACCOUNTFILE));
        }

        if(!File.Exists(ApplicationConstants.FileConstants.TRANSACTION))
        {
            File.Create(Path.Combine(Directory.GetCurrentDirectory(),ApplicationConstants.FileConstants.TRANSACTION));
        }
        Console.ResetColor();
        CustomerRepository.LoadInitialData();
        AccountRepository.LoadInitialAcctData();
        TransactionRepository.LoadInitialTransactionData();
        var main = new Main();
        main.LandingMenu();
    }
}