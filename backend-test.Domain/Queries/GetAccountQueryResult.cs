using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Queries
{
    public class GetBalanceQueryResult
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
