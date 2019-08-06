using backendtest.Shared.Entities;
using System;
using System.Collections.Generic;

namespace backend_test.Domain.Entities
{
    public class Account : Entity
    {
        public Account(Customer holder, double initialValue)
        {
            Holder = holder;
            Balance = new Balance(initialValue);
        }

        public Customer Holder { get; private set; }

        public Balance Balance { get; private set; }

        public void Calculate(Transaction credit)
        {
            Operation
           .InitializeFactories()
           .ExecuteCreation(credit.Type, credit)
           .Operate(Balance);
        }
              
        public bool Cancel(Guid id)
        {
            return Balance.Cancel(id);
        }

        public void AddTransactions(IList<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                Calculate(transaction);
            }
        }
    }
}
