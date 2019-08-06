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
            var customer = new Customer(new Domain.ValueObjects.Name("Andrew", "Mak"), new Domain.ValueObjects.Document("421040188-97"), new Domain.ValueObjects.Email("andrew.cm.sp@gmail.com"), "11982694242");
            var transaction = new List<Transaction>();
            var account = new Account(customer, new Balance(transaction));
            account.Balance.Debit(new Transaction(DateTime.Now, "Conta Rafaela", 1000.50, Domain.Enums.ECategory.Outros));
            account.Balance.Credit(new Transaction(DateTime.Now, "Droga Raia", 100, Domain.Enums.ECategory.Higiene));
            account.Balance.Credit(new Transaction(DateTime.Now, "Bilhete Unico", 150, Domain.Enums.ECategory.Transporte));
            var teste = account.Balance.Value;

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
