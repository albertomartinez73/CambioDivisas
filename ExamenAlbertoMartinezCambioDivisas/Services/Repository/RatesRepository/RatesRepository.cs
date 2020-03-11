using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Services.Factory;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Repository.RatesRepository
{
    public class RatesRepository : GenericRepository<Rates>, IRatesRepository
    {
        IRateFactory ratesFactory;

        public RatesRepository()
        {
            this.ratesFactory = new RateFactory();
        }

        public RatesRepository(IRateFactory rateFactory)
        {
            this.ratesFactory = rateFactory;
        }
        public override async Task LoadData()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync("http://quiet-stone-2094.herokuapp.com/rates.json").Result;
                    List<Rates> rates;
                    string content = response.Content.ReadAsStringAsync().Result;
                    {
                        rates = this._jsonConverter.DeserializeJson(content);
                    }

                    this._table.RemoveRange(this._table);

                    var ratesList = this.ratesFactory.CreateRatesList(rates);
                    this._table.AddRange(ratesList);

                    await this._divisasContext.SaveChangesAsync();

                }
                catch (HttpRequestException) { }
                catch (Exception ex)
                {
                    throw new RepositoryException("Ha habido un problema con el repositorio de Rates: RatesRepository.", ex);
                }
            }

        }
    }
}