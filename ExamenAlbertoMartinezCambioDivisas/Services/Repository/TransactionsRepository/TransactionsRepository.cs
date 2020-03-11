using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Models.ViewModel;
using ExamenAlbertoMartinezCambioDivisas.Services.Factory;
using ExamenAlbertoMartinezCambioDivisas.Services.MonedaConverter;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Repository.TransactionsRepository
{
    public class TransactionsRepository : GenericRepository<Transactions>, ITransactionsRepository
    {
        protected ITransactionsFactory transactionsFactory;
        protected IMonedaConversor moneyConverter;

        public TransactionsRepository()
        {
            this.transactionsFactory = new TransactionFactory();
            this.moneyConverter = new MonedaConversor();
        }

        public TransactionsRepository(ITransactionsFactory factory, IMonedaConversor converter)
        {
            this.transactionsFactory = factory;
            this.moneyConverter = converter;
        }
        public override async Task LoadData()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync("http://quiet-stone-2094.herokuapp.com/transactions.json").Result;
                    List<Transactions> transactions;
                    string content = response.Content.ReadAsStringAsync().Result;
                    {
                        transactions = this._jsonConverter.DeserializeJson(content);
                    }

                    this._table.RemoveRange(this._table);

                    var transactionsList = this.transactionsFactory.CreateTransactionsList(transactions);
                    this._table.AddRange(transactionsList);

                    await this._divisasContext.SaveChangesAsync();
                }
                catch (HttpRequestException) { }
                catch (Exception ex) { throw new RepositoryException("Fallo en el repositorio Transaction", ex); }
            }
        }

        public List<ListadoPorSkuVM> ListadoSku()
        {
            //this.moneyConverter.LoadRatesData(this._divisasContext.Rates.ToList());

            var listadoSku = new List<ListadoPorSkuVM>();
            var query = from transaccion in this._table
                        group transaccion by transaccion.Sku into transaccionSku
                        select new
                        {
                            Sku = transaccionSku.Key,
                            SumaTotal = transaccionSku.Sum(x => x.Amount),
                            //SumaTotal = transaccionSku.Sum(x =>
                            //    this.moneyConverter.ValueConverter(x.Amount, x.Currency, "EUR")),
                            Moneda = "EUR"
                        };

            foreach (var item in query)
            {
                var sku = new ListadoPorSkuVM
                {
                    Sku = item.Sku,
                    SumaAmounts = item.SumaTotal,
                    Moneda = "EUR"
                };

                listadoSku.Add(sku);
            }

            return listadoSku;
        }

        public List<Transactions> TransactionsPorSku(string sku)
        {
            var query = from transaccion in this._table
                        where transaccion.Sku == sku
                        select transaccion;

            //foreach (var item in query)
            //{
            //    item.Amount = this.moneyConverter.ValueConverter(item.Amount, item.Currency, "EUR");
            //    item.Currency = "EUR";
            //}

            return query.ToList();
        }
    }
}