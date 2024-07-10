namespace AutomatedTellerMachineApp.Services
{
    public class HomeService : IHomeService
    {
        IMenuService menuService;
        public HomeService()
        {
            menuService = new MenuService();
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

                    Console.WriteLine("====== Menu ======\n");
                    Console.WriteLine(menu);

                    Console.Write("\n\nChoose an option  ");
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
                    Console.WriteLine("\nTransaction successful. " +
                        "Would you like to perform " +
                        "another transaction? y/n");

                    string userInput2 = Console.ReadLine().ToLower();
                    keepRunning = userInput2 == "y" ||
                        userInput2 == "yes" || userInput2 == "yeap";
                    

                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("\nEnter only 1 2 3 4 5 numbers!!! Try again");
                    Console.WriteLine(Environment.NewLine);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"\n{exception.Message}. Try Again");
                    Console.WriteLine(Environment.NewLine);
                }            
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
