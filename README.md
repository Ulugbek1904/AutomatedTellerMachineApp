# Bankomat App

Welcome to the Bankomat App! This application simulates an ATM system where users can perform various banking operations such as checking their balance, withdrawing cash, changing their PIN, and updating their phone number.

## Features

- **Check Balance**: View the current balance of your account.
- **Withdraw Cash**: Withdraw a specified amount from your account.
- **Change PIN**: Update your ATM PIN code securely.
- **Change Phone Number**: Update the phone number linked to your account.
- **View Transaction History**: View a history of your transactions.
- **Card Blocking**: If incorrect PIN is entered multiple times, the card gets blocked for security reasons.


## Usage

1. **Start the Application**:
    - Run the application using `dotnet run`.

2. **Authenticate**:
    - Enter your PIN code. You have 3 attempts before the application waits for 1 minute. After 5 incorrect attempts, the card will be blocked.

    ![Authentication](https://github.com/Ulugbek1904/AutomatedTellerMachineApp/blob/main/images/Authentication1.png?raw=true)

3. **Main Menu**:
    - Choose from the following options:
        1. Check balance
        2. Withdraw cash
        3. Settings
        4. Card history
        5. Exit

    ![Main Menu](./images/main_menu.png)

4. **Check Balance**:
    - View your current balance.

    ![Check Balance](./images/check_balance.png)

5. **Withdraw Cash**:
    - Select an amount to withdraw.

    ![Withdraw Cash](./images/withdraw_cash.png)

6. **Change PIN**:
    - Update your PIN code securely.

    ![Change PIN](./images/change_pin.gif)

7. **Change Phone Number**:
    - Update the phone number linked to your account.

    ![Change Phone Number](./images/change_phone_number.gif)
