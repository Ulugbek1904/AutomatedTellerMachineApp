using AutomatedTellerMachineApp.GitAutomatedTellerMachineApp.Services;
using AutomatedTellerMachineApp.Models;

namespace AutomatedTellerMachineApp.Services
{
    internal class SettingsService : ISettingsService
    {
        Account account;
        LogerService logerService;
        public SettingsService()
        {
            logerService = new V1LoggerService();
            account = new Account();
        }
        public void ChangePassword()
        {
            bool pinChanged = false;
            int attempts = 0;

            while (!pinChanged && attempts < 3)
            {
                logerService.LogInformation("Enter current PIN: ");
                string currentPin = Console.ReadLine();

                if (currentPin != account.NewPin)
                {
                    attempts++;
                    logerService.LogInformation("Incorrect current PIN. Try again.");
                    if (attempts >= 3)
                    {
                        logerService.LogInformation("Too much effort. Try again later.");
                        return;
                    }
                }
                else
                {
                    while (!pinChanged)
                    {
                        try
                        {
                            logerService.LogInformation("Enter new PIN: ");
                            string newPin = Console.ReadLine();

                            if (newPin.Length != 4 || !int.TryParse(newPin, out _))
                            {
                                throw new ArgumentOutOfRangeException("PIN must be a 4-digit number.");
                            }

                            logerService.LogInformation("Re-enter new PIN: ");
                            string newPin2 = Console.ReadLine();

                            if (newPin != newPin2)
                            {
                                logerService.LogInformation("The PINs must be the same. Try again.");
                            }
                            else
                            {
                                account.NewPin = newPin2;
                                logerService.LogInformation("PIN successfully changed.");
                                pinChanged = true;
                            }
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            logerService.LogInformation($"{ex.Message} Try again!");
                        }
                        catch (Exception ex)
                        {
                            logerService.LogInformation($"{ex.Message} Try again!");
                        }
                    }
                }
            }
        }

        public void ChangePhoneNumber()
        {
            bool phoneNumberChanged = false;
            while (!phoneNumberChanged)
            {
                try
                {
                    logerService.LogInformation("Enter new phone number: ");
                    string newPhoneNumber = Console.ReadLine();

                    if (string.IsNullOrEmpty(newPhoneNumber))
                        throw new ArgumentException("This space must be filled.");
                    else if (!newPhoneNumber.StartsWith("+"))
                        throw new ArgumentException("Phone Number must start with +.");
                    else if (newPhoneNumber.Length < 13 || newPhoneNumber.Length > 13)
                        throw new ArgumentException("Invalid phone number length.");

                    account.CurrentPhoneNumber = newPhoneNumber;
                    logerService.LogInformation("Phone number successfully changed to: " + newPhoneNumber);
                    phoneNumberChanged = true;
                }
                catch (ArgumentException ex)
                {
                    logerService.LogInformation(ex.Message);
                }
            }
        }
    }
}
