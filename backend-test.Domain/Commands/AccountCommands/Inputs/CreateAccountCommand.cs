using backend_test.Shared.Commands;
using backendtest.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Commands.AccountCommands.Inputs
{
    public class CreateAccountCommand : Command, ICommand
    {
        public Guid Customer { get; set; }

        public Guid Number { get; set; }

        public double InitialValue { get; set; }
    }
}
