using AutomatedTellerMachineApp.Models;

namespace AutomatedTellerMachineApp.Services
{
    internal class SettingsService : ISettingsService
    {
        Account account;
        public SettingsService()
        {
            account = new Account();
        }
        public void ChangePassword()
        {
            bool pinChanged = false;
            int attempts = 0;

            while (!pinChanged && attempts < 3)
            {
                Console.Write("Enter current PIN: ");
                string currentPin = Console.ReadLine();

                if (currentPin != account.NewPin)
                {
                    attempts++;
                    Console.WriteLine("Incorrect current PIN. Try again.");
                    if (attempts >= 3)
                    {
                        Console.WriteLine("Too much effort. Try again later.");
                        return;
                    }
                }
                else
                {
                    while (!pinChanged)
                    {
                        try
                        {
                            Console.Write("Enter new PIN: ");
                            string newPin = Console.ReadLine();

                            if (newPin.Length != 4 || !int.TryParse(newPin, out _))
                            {
                                throw new ArgumentOutOfRangeException("PIN must be a 4-digit number.");
                            }

                            Console.Write("Re-enter new PIN: ");
                            string newPin2 = Console.ReadLine();

                            if (newPin != newPin2)
                            {
                                Console.WriteLine("The PINs must be the same. Try again.");
                            }
                            else
                            {
                                account.NewPin = newPin2;
                                Console.WriteLine("PIN successfully changed.");
                                pinChanged = true;
                            }
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine($"{ex.Message} Try again!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message} Try again!");
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
                    Console.Write("Enter new phone number: ");
                    string newPhoneNumber = Console.ReadLine();

                    if (string.IsNullOrEmpty(newPhoneNumber))
                        throw new ArgumentException("This space must be filled.");
                    else if (!newPhoneNumber.StartsWith("+"))
                        throw new ArgumentException("Phone Number must start with +.");
                    else if (newPhoneNumber.Length < 13 || newPhoneNumber.Length > 13)
                        throw new ArgumentException("Invalid phone number length.");

                    account.CurrentPhoneNumber = newPhoneNumber;
                    Console.WriteLine("Phone number successfully changed to: " + newPhoneNumber);
                    phoneNumberChanged = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
