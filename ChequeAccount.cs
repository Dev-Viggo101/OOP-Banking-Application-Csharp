using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    internal class ChequeAccount : BankAccount
    {
        private const float OverdraftLimit = 1000f;

        public ChequeAccount(int accountNumber, string holderName, int pin, float deposit) : base(accountNumber, holderName, pin, deposit)
        {

        }

        public override bool Withdraw(float amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if ((Balance - amount) < -OverdraftLimit)
            {
                return false;
            }

            Balance -= amount;
            transactions.Add(new Transaction("Withdrawal", amount, Balance));
            return true;
        }
    }
}
