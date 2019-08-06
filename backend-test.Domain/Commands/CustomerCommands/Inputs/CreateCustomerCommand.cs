

using backendtest.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace backend_test.Domain.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public CreateCustomerCommand(string firstName, string lastName, string document, string email, string phone)
        {
            AddNotifications(new Contract()
            .HasMinLen(firstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
            .HasMaxLen(firstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
            .HasMinLen(lastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
            .HasMaxLen(lastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres")
            .IsEmail(email, "Email", "O E-mail é inválido")
            .HasLen(document, 11, "Document", "CPF inválido")
            );
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}