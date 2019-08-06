using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Entities
{
    public class Balance
    {
        public Balance(IList<Transaction> transactions)
        {
            Transactions = transactions;
        }
        public IList<Transaction> Transactions { get; private set; }

        public double Value { get; set; }

        public void Credit(Transaction credit)
        {
            Value -= credit.Value;
            Transactions.Add(credit);
        }

        public void Debit(Transaction debit)
        {
            Value += debit.Value;
            Transactions.Add(debit);
        }
    }
}
