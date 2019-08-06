using backendtest.Shared.Entities;

namespace backend_test.Domain.Entities
{
    public class Account : Entity
    {
        public Account(Customer holder, Balance balance)
        {
            Holder = holder;
            Balance = balance;
        }

        public Customer Holder { get; private set; }

        public Balance Balance { get; private set; }

        public void Credit(Transaction credit)
        {
            Balance.Credit(credit);
        }

        public void Debit(Transaction debit)
        {
            Balance.Debit(debit);
        }
    }
}
