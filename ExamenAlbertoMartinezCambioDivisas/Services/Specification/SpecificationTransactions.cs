using ExamenAlbertoMartinezCambioDivisas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Specification
{
    public class SpecificationTransactions : ISpecificationTransactions
    {
        public bool IsSatisfyiedBy(Transactions transactions)
        {
            if (!transactions.Sku.Equals("") && !transactions.Currency.Equals(""))
            {
                return true;

            } else
            {
                return false;
            }
        }
    }
}