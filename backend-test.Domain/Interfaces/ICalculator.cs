using backend_test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Interfaces
{
    public interface ICalculator
    {
        void Operate(Balance balance);
    }
}
