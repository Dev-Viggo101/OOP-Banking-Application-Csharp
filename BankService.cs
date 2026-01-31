using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    internal class BankService
    {
        private List<BankAccount> accounts;

        private int nextAccountNumber;

        public BankService()
        {
            accounts = new List<BankAccount>();
            nextAccountNumber = 100000;
        }


        public int CreateSavingsAccount(string holderName, int pin, float initialDeposit)
        {
            if (initialDeposit <= 0)
                throw new ArgumentException("Initial deposit must be positive");

            int accountNumber = nextAccountNumber++;

            SavingsAccount account = new SavingsAccount(
                accountNumber,
                holderName,
                pin,
                initialDeposit
            );

            accounts.Add(account);
            return accountNumber;
        }

        public int CreateChequeAccount(string holderName, int pin, float initialDeposit)
        {
            if (initialDeposit <= 0)
                throw new ArgumentException("Initial deposit must be positive");

            int accountNumber = nextAccountNumber++;

            ChequeAccount account = new ChequeAccount(
                accountNumber,
                holderName,
                pin,
                initialDeposit
            );

            accounts.Add(account);
            return accountNumber;
        }
     
        public BankAccount FindAccount(int accountNumber)
        {
            return accounts.Find(acc => acc.AccountNumber == accountNumber);
        }

        public BankAccount Login(int accountNumber, int pin)
        {
            var account = FindAccount(accountNumber);

            if (account == null)
            {
                return null;
            }

            if (account.VerifyPin(pin) == false)
            {
                return null;
            }

            return account;
        } 
    }
}
