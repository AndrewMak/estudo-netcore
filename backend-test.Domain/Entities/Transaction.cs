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
            ECategory category, EType type)
        {
            CreateDate = createDate;
            Description = description;
            Value = value;
            Category = category;
            Status = EStatus.Pendent;
            Type = type;
        }
        public DateTime CreateDate { get; private set; }

        public string Description { get; private set; }

        private double Value { get; set; }

        public ECategory Category { get; private set; }

        public EStatus Status { get; private set; }
        public EType Type { get; private set; }


        public override string ToString() => $@"Log[CreateDate:{CreateDate}, Description:{Description}, Value:{Value}, Category:{Category}]";

        public double GetValue()
        {
            return Value;
        }
        public void Cancel()
        {
            Status = EStatus.Canceled;
        }

        public void Confirm()
        {
            Status = EStatus.Paid;
        }

    }
}

