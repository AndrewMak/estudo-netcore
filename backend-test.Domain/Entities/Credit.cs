using backend_test.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Entities
{
    public class CreditFactory : OperationFactory
    {
        public override ICalculator Create(Transaction transaction) => new Credit(transaction);
    }
    public class Credit : ICalculator
    {
        private readonly Transaction _transaction;

        public Credit(Transaction transaction)
        {
            _transaction = transaction;
        }

        public void Operate(Balance balance)
        {
            balance.Credit(_transaction);
        }
    }
}
