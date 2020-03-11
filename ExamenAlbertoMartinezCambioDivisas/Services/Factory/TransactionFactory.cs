using ExamenAlbertoMartinezCambioDivisas.Models;
using System;
using System.Collections.Generic;
using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using ExamenAlbertoMartinezCambioDivisas.Services.Specification;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Factory
{
    public class TransactionFactory : ITransactionsFactory
    {
        private ISpecificationTransactions specificationTransactions = new SpecificationTransactions();
        private List<Transactions> _transactionList = new List<Transactions>();
        public List<Transactions> CreateTransactionsList(List<Transactions> transactionList)
        {
            try
            {
                foreach (var item in transactionList)
                {
                    if (this.specificationTransactions.IsSatisfyiedBy(item) == true)
                    {
                        this._transactionList.Add(item);
                    }
                    else { 
                        throw new FactoryException("No se ha podido crear el objeto transactions: TransactionFactory");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FactoryException("No se ha podido crear el objeto transactions: TransactionFactory", ex);

            }
            return this._transactionList;
        }
    }
}