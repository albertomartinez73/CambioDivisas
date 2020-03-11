using System.Collections.Generic;
using ExamenAlbertoMartinezCambioDivisas.Models;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Factory
{
    public interface ITransactionsFactory
    {
        //List<Transactions> ListaTransactions();
        //void CreateTransaction(Transactions transaction);

        List<Transactions> CreateTransactionsList(List<Transactions> transactionList);
    }
}
