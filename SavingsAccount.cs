using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    internal class SavingsAccount : BankAccount
    {
        private const float InterestRate = 0.05f;

        public SavingsAccount(int accountNumber, string holderName, int pin, float balance) : base(accountNumber, holderName, pin, balance)
        {
            
        }

        public override bool ApplyInterest()
        {
            if(Balance <= 0) return false;

            float interest = Balance * InterestRate;
            Balance += interest;
            transactions.Add(new Transaction("Interest", interest, Balance));
            return true;
        }
    }
}
