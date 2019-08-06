using backend_test.Domain.Entities;
using backend_test.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Repositories
{
    public interface IAccountRepository
    {
        void Save(Account customer);
        GetBalanceQueryResult GetBalance(Guid id);
        GetBalanceQueryResult GetTransactions(Guid id);
    }
}
