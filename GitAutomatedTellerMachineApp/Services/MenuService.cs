using AutomatedTellerMachineApp.Models;

namespace AutomatedTellerMachineApp.Services
{
    internal class MenuService : IMenuService
    {
        ISettingsService settingsService;
        Account account;
        public MenuService()
        {
            account = new Account();
            settingsService = new SettingsService();
        }
        public void DisplayBalance()
        {   
            Console.WriteLine($"Your balance :" +
                $" {account.CurrentBalance}$");
        }

        public void WithdrawCash()
        {
            bool continueProgram = true;
            while (continueProgram)
            {
                try
                {
                    Console.WriteLine("\n1 => 10$".
                        PadRight(40) + "2 => 20$");
                    Console.WriteLine("3 => 50$".
                        PadRight(40) + "4 => 100$");
                    Console.WriteLine("5. Another amount.\n");

                    Console.Write("Select one : ");
                    string userInput = Console.ReadLine();
                    int intUserInput = int.Parse(userInput);

                    decimal amount = 0;
                    switch(intUserInput)
                    {
                        case 1:
                            amount = 10;
                            break;
                        case 2:
                            amount = 20;
                            break;
                        case 3:
                            amount = 50;
                            break;
                        case 4:
                            amount = 100;
                            break;
                        case 5:
                            Console.Write("Amount : ");
                            decimal amount2 = decimal.
                                Parse(Console.ReadLine());
                            amount = amount2;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    if (amount  > 0 && amount <= 
                        account.CurrentBalance - (amount/100))
                    {
                        account.CurrentBalance -= (amount + amount/100);
                        account.TransferHistory.Add(amount + amount/100);

                        Console.WriteLine($"total amount: " +
                            $"{amount + amount/100}$\n" +
                            $"transaction fee : {amount/100}$");

                        Console.WriteLine("press enter to confirm ");
                        Console.ReadLine();
                        Thread.Sleep(500);
                        Console.WriteLine("Get your cash");
                        Thread.Sleep(7000);
                        continueProgram = false;
                    } 
                    else 
                        Console.WriteLine("Incorrect amount entered or" +
                            " insufficient balance available");

                }
                catch (ArgumentOutOfRangeException exp)
                {
                    Console.WriteLine($"{exp.Message} Try again");
                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }

        }

        public void DisplayHistory()
        {
            if (account.TransferHistory.Count > 0)
            {
                Console.WriteLine("History of withdrawals:");
                foreach (var transfer in account.TransferHistory)
                {
                    Console.WriteLine($"- {transfer}$");
                }
            }
            else
            {
                Console.WriteLine("the card has not been debited yet.");
            }
        }

        public void Settings()
        {
            Console.WriteLine("1 => Change phone Number");
            Console.WriteLine("2 => Change PIN code");
            Console.Write("Your choice : ");
            try
            {
                string userInput = Console.ReadLine();
                int intInpit = int.Parse(userInput);

                switch (intInpit)
                {
                    case 1:
                        Console.Clear();
                        settingsService.ChangePhoneNumber();
                        break;
                    case 2:
                        Console.Clear();
                        settingsService.ChangePassword();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message} Try again");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message} Try again");
            }
        }
    }
}
