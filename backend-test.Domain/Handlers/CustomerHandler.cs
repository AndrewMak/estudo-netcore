using backend_test.Domain.CustomerCommands.Inputs;
using backend_test.Domain.Repositories;
using backend_test.Domain.Services;
using backend_test.Domain.ValueObjects;
using backendtest.Shared.Commands;
using Flunt.Notifications;

namespace backend_test.Domain.Handlers
{
    public class CustomerHandler :
           Notifiable,
           ICommandHandler<CreateCustomerCommand>,
           ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            // Verificar se o E-mail já existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail já está em uso");

            // Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new backend_test.Domain.Entities.Customer(name, document, email, command.Phone);

            // Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(
                    false,
                    "Por favor, corrija os campos abaixo",
                    Notifications);

            // Persistir o cliente
            _repository.Save(customer);

            // Enviar um E-mail de boas vindas
            _emailService.Send(email.Address, "hello@balta.io", "Bem vindo", "Seja bem vindo ao Balta Store!");

            // Retornar o resultado para tela
            return new CommandResult(true, "Bem vindo ao balta Store", new
            {
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
