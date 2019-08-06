using backend_test.Domain.Entities;
using backend_test.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);
    }
}
