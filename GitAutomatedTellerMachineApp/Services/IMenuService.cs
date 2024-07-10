namespace AutomatedTellerMachineApp.Services
{
    internal interface IMenuService
    {
        void DisplayBalance();
        void WithdrawCash();
        void Settings();
        void DisplayHistory();
    }
}
