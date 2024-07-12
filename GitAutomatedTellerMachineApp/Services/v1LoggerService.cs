namespace AutomatedTellerMachineApp.GitAutomatedTellerMachineApp.Services
{
    public class V1LoggerService : LogerService
    {
        public override void LogInformation(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
