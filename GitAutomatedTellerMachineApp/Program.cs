using AutomatedTellerMachineApp.Models;
using AutomatedTellerMachineApp.Services;

namespace AutomatedTellerMachineApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHomeService homeService = new HomeService();
            Account account = new Account();
            int count = 0;
            bool isAuthenticated = false;
            while (!isAuthenticated)
            { 
                Console.Write("Enter PIN code : ");
                string userInput = Console.ReadLine();
                if (userInput == account.NewPin)
                {
                    Console.Clear();
                    isAuthenticated = true;
                    Console.WriteLine("\t\t\t\t Welcome to the Bankomat App");
                    homeService.LoadExistedMenus();
                }
                else
                {
                    count++;
                    if (count == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Too much effort. Try again 1 minute later");
                        Thread.Sleep(60000);
                    }
                    else if(count == 5)
                    {
                        Console.WriteLine("your card has been blocked. Contact your bank to open");
                        Thread.Sleep(10000);
                        Console.Clear();
                        isAuthenticated = true;
                    }
                    Console.WriteLine("Incorrect PIN. Try again");
                }
            }
            
        }
    }
}