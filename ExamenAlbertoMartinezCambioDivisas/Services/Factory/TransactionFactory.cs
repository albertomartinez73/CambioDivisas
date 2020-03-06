using ExamenAlbertoMartinezCambioDivisas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using ExamenAlbertoMartinezCambioDivisas.Services.Specification;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Factory
{
    public class TransactionFactory : ITransactionsFactory
    {
        private Transactions Transactions;
        ISpecificationTransactions transactionsSpecification = new SpecificationTransactions();
        public List<Transactions> ListadoTransanctions { get; set; } = new List<Transactions>();
        public void CreateTransaction(Transactions transaction)
        {
            try
            {
                if (transactionsSpecification.IsSatisfyiedBy(transaction))
                {
                    this.Transactions = new Transactions
                    {
                        Sku = transaction.Sku,
                        Currency = transaction.Currency,
                        Amount = transaction.Amount
                    };

                    this.ListadoTransanctions.Add(this.Transactions);
                } else
                {
                    throw new SpecificationException("Error en SpecificationTransactions: No se pudo crear el elemento Transaction.");
                }                    

            }
            catch (Exception e)
            {
                throw new TransactionsFactoryExceptions("Error en TransactionsFactory ", e);
            }
        }

        public List<Transactions> ListaTransactions()
        {
            return this.ListadoTransanctions;
        }
    }
}