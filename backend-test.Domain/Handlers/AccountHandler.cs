using backend_test.Domain.Commands.AccountCommands.Inputs;
using backendtest.Shared.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Handlers
{
    public class AccountHandler : Notifiable, ICommandHandler<CreateAccountCommand>
    {
        public AccountHandler()
        {
            //repositorio de account
            //repositorio de balance
            //repositorio de customer
        }
        public ICommandResult Handle(CreateAccountCommand command)
        {
            //criar o account, gerar um guid de numero de conta
            //criar um balance, se tiver valor inicial uma transaction de valor incial, status paid.
            //retornar sucesso 200 http result genericResultCommand
            
            throw new NotImplementedException();
        }
    }
}
