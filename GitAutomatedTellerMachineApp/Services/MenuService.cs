using AutomatedTellerMachineApp.GitAutomatedTellerMachineApp.Services;
using AutomatedTellerMachineApp.Models;

namespace AutomatedTellerMachineApp.Services
{
    internal class MenuService : IMenuService
    {
        LogerService logerService;
        ISettingsService settingsService;
        Account account;
        public MenuService()
        {
            logerService = new V1LoggerService();
            account = new Account();
            settingsService = new SettingsService();
        }
        public void DisplayBalance()
        {
            logerService.LogInformation($"Your balance :" +
                $" {account.CurrentBalance}$");
        }

        public void WithdrawCash()
        {
            bool continueProgram = true;
            while (continueProgram)
            {
                try
                {
                    logerService.LogInformation("\n1 => 10$".
                        PadRight(40) + "2 => 20$");
                    logerService.LogInformation("3 => 50$".
                        PadRight(40) + "4 => 100$");
                    logerService.LogInformation("5. Another amount.\n");

                    logerService.LogInformation("Select one : ");
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
                            logerService.LogInformation("Amount : ");
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

                        logerService.LogInformation($"total amount: " +
                            $"{amount + amount/100}$\n" +
                            $"transaction fee : {amount/100}$");

                        logerService.LogInformation("press enter to confirm ");
                        Console.ReadLine();
                        Thread.Sleep(500);
                        logerService.LogInformation("Get your cash");
                        Thread.Sleep(7000);
                        continueProgram = false;
                    } 
                    else
                        logerService.LogInformation("Incorrect amount entered or" +
                            " insufficient balance available");

                }
                catch (ArgumentOutOfRangeException exp)
                {
                    logerService.LogInformation($"{exp.Message} Try again");
                }
                catch(Exception exp)
                {
                    logerService.LogInformation(exp.Message);
                }
            }

        }

        public void DisplayHistory()
        {
            if (account.TransferHistory.Count > 0)
            {
                logerService.LogInformation("History of withdrawals:");
                foreach (var transfer in account.TransferHistory)
                {
                    logerService.LogInformation($"- {transfer}$");
                }
            }
            else
            {
                logerService.LogInformation("the card has not been debited yet.");
            }
        }

        public void Settings()
        {
            logerService.LogInformation("1 => Change phone Number");
            logerService.LogInformation("2 => Change PIN code");
            logerService.LogInformation("Your choice : ");
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
                logerService.LogInformation($"{ex.Message} Try again");
            }
            catch(ArgumentException ex)
            {
                logerService.LogInformation($"{ex.Message} Try again");
            }
        }
    }
}
