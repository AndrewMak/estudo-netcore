using System;
using System.Collections.Generic;
using System.Text;

namespace backend_test.Domain.Services
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string body);
    }
}
