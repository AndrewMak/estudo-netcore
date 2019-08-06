using backend_test.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace backend_test.Domain.Entities
{
    public class DebitFactory : OperationFactory
    {
        public override ICalculator Create(Transaction transaction) => new Debit(transaction);
    }
    public class Debit : ICalculator
    {
        private readonly Transaction _transaction;

        public Debit(Transaction transaction)
        {
            _transaction = transaction;
        }

        public void Operate(Balance balance)
        {
            balance.Debit(_transaction);
        }
    }
}
