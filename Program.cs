using Entity;
using Menu;

internal class Program
{
    private static void Main(string[] args)
    {
        // This part is to create the files if the db file doesn't exist
        if(!File.Exists(ApplicationConstants.FileConstants.CUSTOMERFILE))
        {
            File.Create(Path.Combine(Directory.GetCurrentDirectory(), ApplicationConstants.FileConstants.CUSTOMERFILE));
        }
        // Do the same thing to create other files
        Console.ResetColor();
        var main = new Main();
        main.LandingMenu();
    }
}