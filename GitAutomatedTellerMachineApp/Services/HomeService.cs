using AutomatedTellerMachineApp.GitAutomatedTellerMachineApp.Services;

namespace AutomatedTellerMachineApp.Services
{
    public class HomeService : IHomeService
    {
        LogerService logerService;
        IMenuService menuService;
        public HomeService()
        {
            menuService = new MenuService();
            logerService = new V1LoggerService();
        }
        public void LoadExistedMenus()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                try
                {
                    string menu = "1. Check balance\n" +
                    "2. Withdraw cash\n" +
                    "3. Settings\n" +
                    "4. Card history\n" +
                    "5. Card Dispensing";

                    logerService.LogInformation("====== Menu ======\n");
                    logerService.LogInformation(menu);

                    logerService.LogInformation("\n\nChoose an option  ");
                    string userInput = Console.ReadLine();
                    int intInput = int.Parse(userInput);

                    switch (intInput)
                    {
                        case 1:
                            Console.Clear();
                            menuService.DisplayBalance();
                            break;
                        case 2:
                            Console.Clear();
                            menuService.WithdrawCash();
                            break;
                        case 3:
                            Console.Clear();
                            menuService.Settings();
                            break;
                        case 4:
                            Console.Clear();
                            menuService.DisplayHistory();
                            break;
                        case 5:
                            Exit();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    logerService.LogInformation("\nTransaction successful. " +
                        "Would you like to perform " +
                        "another transaction? y/n");

                    string userInput2 = Console.ReadLine().ToLower();
                    keepRunning = userInput2 == "y" ||
                        userInput2 == "yes" || userInput2 == "yeap";
                    

                }
                catch (ArgumentOutOfRangeException)
                {
                    logerService.LogInformation("\n" +
                        "Enter only 1 2 3 4 5 numbers!!! Try again\n");
                    
                }
                catch (Exception exception)
                {
                    logerService.LogInformation($"\n" +
                        $"{exception.Message}. Try Again\n");
                }            
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
