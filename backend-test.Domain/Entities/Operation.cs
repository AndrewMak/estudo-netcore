using backend_test.Domain.Enums;
using backend_test.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Entities
{
    public abstract class OperationFactory
    {
        public abstract ICalculator Create(Transaction transaction);
    }

    public class Operation
    {
        private readonly Dictionary<EType, OperationFactory> _factories;

        private Operation()
        {
            _factories = new Dictionary<EType, OperationFactory>();

            foreach (EType action in Enum.GetValues(typeof(EType)))
            {
                var factory = (OperationFactory)Activator.CreateInstance(Type.GetType("backend_test.Domain.Entities." + Enum.GetName(typeof(EType), action) + "Factory"));
                _factories.Add(action, factory);
            }
        }

        public static Operation InitializeFactories() => new Operation();

        public ICalculator ExecuteCreation(EType action, Transaction transaction) => _factories[action].Create(transaction);
    }
}
