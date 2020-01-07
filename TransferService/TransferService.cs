using BSDatabaseContext;
using Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TransferService
{
    public static class TransferService
    {
        public static async Task TransferMoneyAsync(Transaction transaction) 
        {
            double debitAmount = -transaction.Amount;
            if (!AccountsBelongToSameUser(transaction.AccountFromId,transaction.AccountToId))
                debitAmount += debitAmount * 0.01;
            ModifyBalance(transaction.AccountFromId, debitAmount);            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://data.fixer.io/api/latest?access_key=6519078b96b6f0e00cd35f85bd65e876&format=1");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //var product = null;
            HttpResponseMessage response = await client.GetAsync("");
            string result = "";
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;;
            }
            string AccountFromCode = GetAccountCurrencyCode(transaction.AccountFromId);
            string AccountToCode = GetAccountCurrencyCode(transaction.AccountToId);
            double exchangeRate = 1;
            if (AccountFromCode!=AccountToCode)
                 exchangeRate = ExchangeRate(result, AccountFromCode, AccountToCode);
            double creditAmount = transaction.Amount * exchangeRate;
            ModifyBalance(transaction.AccountToId, creditAmount);
        }

        private static bool AccountsBelongToSameUser(int accountFromId, int accountToId)
        {
            AccountDataAccess ada = new AccountDataAccess();
            return ada.SameOwner(accountFromId,accountToId);
        }
        private static string GetAccountCurrencyCode(int accountId)
        {
            AccountDataAccess ada = new AccountDataAccess();
            return ada.Get(accountId).Currency.Code;
        }

        public static void ModifyBalance(int accountId,double amount) 
        {
            AccountDataAccess ada = new AccountDataAccess();
            Account account = ada.Get(accountId);
            account.Balance += amount;
            ada.Modify(account);
        }

        private static double ExchangeRate(string data, string from, string to)
        {
            var root = JObject.Parse(data);
            var rates = root.Value<JObject>("rates");
            var fromRate = rates.Value<double>(from);
            var toRate = rates.Value<double>(to);
            var rate = toRate / fromRate;

            return rate;
        }
    }
}
