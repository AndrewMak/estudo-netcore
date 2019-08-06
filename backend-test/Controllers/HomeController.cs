using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend_test.Models;
using backend_test.Domain.Entities;

namespace backend_test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //crio o cliente
            var customer = new Customer(new Domain.ValueObjects.Name("Andrew", "Mak"), new Domain.ValueObjects.Document("421040188-97"), new Domain.ValueObjects.Email("andrew.cm.sp@gmail.com"), "11982694242");
            //var transaction = new List<Transaction>();
            //transaction.Add(new Transaction(DateTime.Now, "Conta Leandro", 500, Domain.Enums.ECategory.Outros, Domain.Enums.EType.Debit));
            //transaction.Add(new Transaction(DateTime.Now, "Conta Igor", 1000, Domain.Enums.ECategory.Outros, Domain.Enums.EType.Debit));
            //transaction.Add(new Transaction(DateTime.Now, "Conta Andrew", 8000, Domain.Enums.ECategory.Outros, Domain.Enums.EType.Debit));
            //transaction.Add(new Transaction(DateTime.Now, "Conta Pedro", 1250.97, Domain.Enums.ECategory.Outros, Domain.Enums.EType.Debit));
            //valor inicial na conta
            var initialValue = 0;
            //crio a conta
            var account = new Account(customer, initialValue);

            //account.AddTransactions(transaction);
            account.Calculate(new Transaction(DateTime.Now, "Conta Rafaela", 1000.50, Domain.Enums.ECategory.Outros, Domain.Enums.EType.Debit));
            account.Calculate(new Transaction(DateTime.Now, "Droga Raia", 1000.50, Domain.Enums.ECategory.Higiene, Domain.Enums.EType.Credit));
            account.Calculate(new Transaction(DateTime.Now, "Bilhete Unico", 150, Domain.Enums.ECategory.Transporte, Domain.Enums.EType.Credit));
            account.Balance.Cancel(account.Balance.GetTransactions().First().Id);
            var transactions = account.Balance.GetTransactions().ToList();
            var teste = account.Balance.Total;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
