using backend_test.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Entities
{
    public class BalanceCalculator
    {
        private ICalculator _calculator;
        private readonly Balance _balance;
        public BalanceCalculator(ICalculator calculator, Balance balance)
        {
            _calculator = calculator;
            _balance = balance;
        }
        public void SetCalculator(ICalculator calculator) => _calculator = calculator;

        //public void Calculate(Transaction transaction) => _calculator.Calculate(_balance, transaction);

    }
}
