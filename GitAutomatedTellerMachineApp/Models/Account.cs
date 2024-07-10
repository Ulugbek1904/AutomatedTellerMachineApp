namespace AutomatedTellerMachineApp.Models
{
    public class Account
    {
        private string _pin = "1234";
        private decimal _initialBalance = 100m;
        private string _initialPhoneNumber = "+998 90 046 19 04";
        public decimal CurrentBalance
        {
            get { return _initialBalance; }
            set { _initialBalance = value; }
        }
        public string CurrentPhoneNumber
        {
            get { return _initialPhoneNumber; }
            set { _initialPhoneNumber = value; }
        }
        public string NewPin
        {
            get { return _pin; }
            set { _pin = value; }
        }
        public List<decimal> TransferHistory { get; private set; }

        public Account()
        {
            TransferHistory = new List<decimal>();
        }
    }
}
