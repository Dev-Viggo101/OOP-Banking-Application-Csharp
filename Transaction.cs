using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    internal class Transaction
    {
        public DateTime Date { get; }
        public string Type { get; }
        public float Amount { get; }
        public float BalanceAfter { get; }

        public Transaction(string type, float amount, float balanceAfter)
        {
            Date = DateTime.Now;
            Type = type;
            Amount = amount;
            BalanceAfter = balanceAfter;
        }
    }
}
