using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using System.Web.Http;
using BankingSystem.ViewModels;
using BSDatabaseContext;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public List<TransactionVM> Get(DateTime dateFrom, DateTime dateTo, int accountFrom)
        {
            if (dateTo == DateTime.MinValue)
                dateTo = DateTime.MaxValue;
            TransactionDataAccess tda = new TransactionDataAccess();
            var transactions = tda.GetAllList().Where(t => t.DateAndTime > dateFrom && t.DateAndTime < dateTo && (t.AccountFrom.AccountId == accountFrom || accountFrom == 0)).Select(t => new TransactionVM()
            {
                TransactionId = t.TransactionId,
                AccountFrom = t.AccountFrom.AccountId,
                AccountTo = t.AccountTo.AccountId,
                DateAndTime = t.DateAndTime,
                Description = t.Description,
                Amount = t.Amount
            }).ToList();
            return transactions;
        }
    }
}

