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
using TransferService;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetTransaction( int transactionId)
        {
            TransactionDataAccess tda = new TransactionDataAccess();
            Transaction transaction = tda.Get(transactionId);
            TransactionVM transactionVM = new TransactionVM()
            {
                TransactionId = transaction.TransactionId,
                AccountFrom = transaction.AccountFrom.AccountId,
                AccountTo = transaction.AccountTo.AccountId,
                DateAndTime = transaction.DateAndTime,
                Description = transaction.Description,
                Amount = transaction.Amount
            };
            return Ok(transactionVM);
        }
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostAsync([FromBody] Transaction transaction)
        {
            try
            {
                if (CheckExistingAccounts(transaction))
                {                    
                    await TransferService.TransferService.TransferMoneyAsync(transaction);
                    TransactionDataAccess tda = new TransactionDataAccess();
                    tda.Add(transaction);
                    return CreatedAtRoute("Get", new { id = transaction.TransactionId },transaction);
                    
                }
                return BadRequest("At least one of the accounts doesn't exist.");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        private bool CheckExistingAccounts(Transaction transaction)
        {
            AccountDataAccess ada = new AccountDataAccess();
            return ada.Exists(transaction.AccountFromId) &&
                ada.Exists(transaction.AccountToId);
        }
    }
}

