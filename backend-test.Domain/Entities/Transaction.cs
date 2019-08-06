using backend_test.Domain.Enums;
using backendtest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Entities
{
    public class Transaction : Entity
    {
        public Transaction(
            DateTime createDate,
            string description,
            double value,
            ECategory category)
        {
            CreateDate = createDate;
            Description = description;
            Value = value;
            Category = category;
        }
        public DateTime CreateDate { get; private set; }

        public string Description { get; private set; }

        public double Value { get; private set; }

        public ECategory Category { get; private set; }

        public override string ToString() => $@"Log[CreateDate:{CreateDate}, Description:{Description}, Value:{Value}, Category:{Category}]";
    }
}

