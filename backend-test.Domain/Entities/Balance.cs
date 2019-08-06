using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace backend_test.Domain.Entities
{
    public class Balance
    {
        private readonly IList<Transaction> _transactions;

        public Balance(double initialValue)
        {
            Total = initialValue;
            _transactions = new List<Transaction>();
            CreateDate = DateTime.Now;
        }
        public DateTime CreateDate { get; private set; }

        public double Total { get; private set; }

        public void Credit(Transaction credit)
        {
            Total -= credit.GetValue();
            _transactions.Add(credit);
        }

        public void Debit(Transaction debit)
        {
            Total += debit.GetValue();
            _transactions.Add(debit);
        }
        public bool Cancel(Guid id)
        {
            var ok = _transactions.First(x => x.Id == id);
            if (ok != null)
            {
                _transactions.Where(x => x.Id == id).ToList().ForEach(x => x.Cancel());
                Credit(ok);
            }
            return true;
        }

        public IList<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}
