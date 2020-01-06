using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingSystem.ViewModels;
using BSDatabaseContext;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public List<TransactionVM> Get()
        {
            TransactionDataAccess tda = new TransactionDataAccess();
                return tda.GetAllList().Select(t => new TransactionVM()
                {
                    TransactionId = t.TransactionId,
                    AccountFrom = t.AccountFrom.AccountId,
                    AccountTo = t.AccountTo.AccountId,
                    DateAndTime = t.DateAndTime,
                    Description = t.Description,
                    Amount=t.Amount
                }).ToList();
            
            
        }
    }
}
