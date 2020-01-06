using BSDatabaseContext;
using Domain;
using System;

namespace TransferService
{
    public static class TransferService
    {
        public static void TransferMoney(Transaction transaction) 
        {
            double debitAmount = -transaction.Amount;
            if (AccountsBelongToSameUser(transaction.AccountFromId,transaction.AccountToId))
                transaction.Amount= transaction.Amount + transaction.Amount*0.01;
            ModifyBalance(transaction.AccountFromId, debitAmount);
            ModifyBalance(transaction.AccountToId, transaction.Amount);
        }

        private static bool AccountsBelongToSameUser(int accountFromId, int accountToId)
        {
            AccountDataAccess ada = new AccountDataAccess();
            return ada.SameOwner(accountFromId,accountToId);
        }

        public static void ModifyBalance(int accountId,double amount) 
        {
            AccountDataAccess ada = new AccountDataAccess();
            Account account = ada.Get(accountId);
            account.Balance = account.Balance + amount;
            ada.Modify(account);
        }
    }
}
