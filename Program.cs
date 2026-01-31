using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{ 
    enum MainMenuOptions
    {
        CreateAccount = 1,
        Login,
        Exit
    }

    enum AccountTypeMenu
    {
        ChequeAccount = 1,
        SavingsAccount,
        Back
    }

    enum PostLoginMenu
    {
        Deposit = 1,
        Withdraw,
        ApplyInterest,
        TransactionHistory,
        Logout      
    }
    internal class Program
    {
        static BankService bankService = new BankService();
        static BankAccount currentAccount;

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Capitec Bank!");
                Console.WriteLine("What would you like to do today?:");
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.WriteLine("");

                if (int.TryParse(Console.ReadLine(), out int option) && Enum.IsDefined(typeof(MainMenuOptions), option))
                {
                    switch ((MainMenuOptions)option)
                    {
                        case MainMenuOptions.CreateAccount:
                            AccountType();
                            break;

                        case MainMenuOptions.Login:
                            Login();
                            break;

                        case MainMenuOptions.Exit:
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option! Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        static void AccountType()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What type of account would you want to create? (1 OR 2):");
                Console.WriteLine("\n1. Cheque Account");
                Console.WriteLine("2. Savings Account");
                Console.WriteLine("3. Back");
                Console.WriteLine("");

                if (int.TryParse(Console.ReadLine(), out int option) && Enum.IsDefined(typeof(AccountTypeMenu), option))
                {
                    switch ((AccountTypeMenu)option)
                    {
                        case AccountTypeMenu.ChequeAccount:
                            ChequeAccount();
                            break;

                        case AccountTypeMenu.SavingsAccount:
                            SavingsAccount();
                            break;

                        case AccountTypeMenu.Back:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option! Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        static void ChequeAccount()
        {
            Console.Clear();

            int requiredLength = 4;

            Console.WriteLine("Enter account holder name:");
            string accountHolder = Console.ReadLine();

            Console.WriteLine("\nCreate a 4-digit PIN:");
            if(!int.TryParse(Console.ReadLine(), out int pin))
            {
                Console.WriteLine("PIN needs to be digits only!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }
            
            string pinCon = pin.ToString();

            if(pinCon.Length != requiredLength)
            {
                Console.WriteLine("PIN needs to be 4-digits only!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nEnter initial deposit amount:");
            if (!float.TryParse(Console.ReadLine(), out float deposit))
            {
                Console.WriteLine("Deposit needs to be digits only!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            if(deposit <= 0)
            {
                Console.WriteLine("Initial deposit needs to be greater than 0!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            int accountNumber = bankService.CreateChequeAccount(accountHolder, pin, deposit);
            Console.WriteLine("Cheque Account has been created successfully!");
            Console.WriteLine($"Your account number is: {accountNumber}");
            Console.WriteLine("Make sure to write it down for logging in.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void SavingsAccount()
        {
            Console.Clear();

            int requiredLength = 4;

            Console.WriteLine("Enter account holder name:");
            string accountHolder = Console.ReadLine();

            Console.WriteLine("\nCreate a 4-digit PIN:");
            if (!int.TryParse(Console.ReadLine(), out int pin))
            {
                Console.WriteLine("PIN needs to be digits only!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            string pinCon = pin.ToString();

            if (pinCon.Length != requiredLength)
            {
                Console.WriteLine("PIN needs to be 4-digits only!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nEnter initial deposit amount:");
            if (!float.TryParse(Console.ReadLine(), out float deposit))
            {
                Console.WriteLine("Deposit needs to be digits only!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            if (deposit <= 0)
            {
                Console.WriteLine("Initial deposit needs to be greater than 0!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            int accountNumber = bankService.CreateSavingsAccount(accountHolder, pin, deposit);
            Console.WriteLine("Savings Account has been created successfully!");
            Console.WriteLine($"Your account number is: {accountNumber}");
            Console.WriteLine("Make sure to write it down for logging in.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void Login()
        {
            Console.Clear();
            int accountNumberLength = 6;
            int pinLength = 4;

            Console.WriteLine("💡 Tip: Your 6-digit account number is required to log in.");
            Console.WriteLine("If you are a new user, make sure you wrote it down from account creation.");
            if (!int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Console.WriteLine("Account Number should be digits only!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            string anCon = accountNumber.ToString();

            if(anCon.Length != accountNumberLength)
            {
                Console.WriteLine("Account Number should be 6 digits only!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter PIN: ");
            if (!int.TryParse(Console.ReadLine(), out int pin))
            {
                Console.WriteLine("PIN should be digits only!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            string pinCon = pin.ToString();

            if (pinCon.Length != pinLength)
            {
                Console.WriteLine("PIN should be 4 digits only!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            var loggedInAccount = bankService.Login(accountNumber, pin);

            if (loggedInAccount == null)
            {
                Console.WriteLine("Login failed! Account number or PIN is incorrect.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }
            else
            {
                currentAccount = loggedInAccount;
                AccountMenu(currentAccount);
            }
        }

        static void AccountMenu(BankAccount account)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do (1-5):");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Apply Interest");
                Console.WriteLine("4. Transaction History");
                Console.WriteLine("5. Logout");
                Console.WriteLine("");

                if (int.TryParse(Console.ReadLine(), out int option) && Enum.IsDefined(typeof(PostLoginMenu), option))
                {
                    switch ((PostLoginMenu)option)
                    {
                        case PostLoginMenu.Deposit:
                            Console.Clear();
                            Console.WriteLine("How much would you like to deposit into your account:");
                            Console.Write("R");
                            if(float.TryParse(Console.ReadLine(), out float deposit))
                            {
                                if(deposit > 0)
                                {
                                    bool success = account.Deposit(deposit);
                                    if(success == true)
                                    {
                                        Console.WriteLine("Deposit was successful!");
                                        Console.WriteLine("Press any key to continue.");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Deposit was unsuccessful! Please try again.");
                                        Console.WriteLine("Press any key to continue.");
                                        Console.ReadKey();
                                        return;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Deposit amount cannot be less than zero! Please try again.");
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                    return;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Deposit should only be entered as digits! Please try again.!");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                return;
                            }
                                break;

                        case PostLoginMenu.Withdraw:
                            Console.Clear();
                            Console.WriteLine("How much would you like to withdraw from your account:");
                            Console.Write("R");
                            if(float.TryParse(Console.ReadLine(),out float withdraw))
                            {
                                bool success = account.Withdraw(withdraw);
                                if(success == true)
                                {
                                    Console.WriteLine("Withdrawal was successful!");
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient funds/Limit exceeded! Please try again.");
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                    return;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Withdrawal should only be entered as digits! Please try again.!");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                return;
                            }
                                break;

                        case PostLoginMenu.ApplyInterest:
                            Console.Clear();
                            bool interestSuccess = account.ApplyInterest();
                            if (interestSuccess)
                            {
                                Console.WriteLine("Interest applied successfully!");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Interest cannot be applied to this account type! Please try again.");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                return;
                            }
                                break;

                        case PostLoginMenu.TransactionHistory:
                            Console.Clear();
                            var history = account.GetTransactionHistory();

                            if(history.Count == 0)
                            {
                                Console.WriteLine("No transactions have been made yet!");
                            }
                            else
                            {
                                Console.WriteLine("--- Transaction History ---");
                                foreach (var transaction in history)
                                {
                                    Console.WriteLine($"{transaction.Date:yyyy-MM-dd HH:mm} | {transaction.Type,-10} | R{transaction.Amount,-8} | Balance: R{transaction.BalanceAfter}");
                                }
                                Console.WriteLine($"\nTotal transactions: {history.Count}");
                                Console.WriteLine($"Current balance: R{account.Balance}");
                            }
                            Console.WriteLine("\nPress any key to continue.");
                            Console.ReadKey();
                                break;

                        case PostLoginMenu.Logout:
                            Console.WriteLine("Logging out");
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option! Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}
