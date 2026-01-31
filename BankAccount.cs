using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    internal class BankAccount
    {    
        public int AccountNumber { get; }
        public string HolderName { get; }
        protected int PIN {  get; }
        public float Balance { get; protected set; }

        protected List<Transaction> transactions = new List<Transaction>();

        protected BankAccount(int accountNumber, string holderName, int pin, float balance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            PIN = pin;
            Balance = balance;
            transactions = new List<Transaction>();
        }

        public bool VerifyPin(int inputPin)
        {
            return PIN == inputPin;
        }

        public virtual bool Withdraw(float amount)
        {
            if (amount <= 0 || amount > Balance) return false;

            Balance -= amount;
            transactions.Add(new Transaction("Withdrawal", amount, Balance));
            return true;
        }

        public virtual bool Deposit(float amount)
        {
            if (amount <= 0) return false;

            Balance += amount;
            transactions.Add(new Transaction("Deposit", amount, Balance));
            return true;
        }

        public virtual bool ApplyInterest()
        {
            return false;
        }

        public List<Transaction> GetTransactionHistory()
        {
            return transactions;
        }
    }
}
