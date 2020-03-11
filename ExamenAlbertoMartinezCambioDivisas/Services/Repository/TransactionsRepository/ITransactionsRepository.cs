using System.Collections.Generic;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Models.ViewModel;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Repository.TransactionsRepository
{
    public interface ITransactionsRepository : IGenericRepository<Transactions>
    {
        List<ListadoPorSkuVM> ListadoSku();
        List<Transactions> TransactionsPorSku(string sku);
    }
}
