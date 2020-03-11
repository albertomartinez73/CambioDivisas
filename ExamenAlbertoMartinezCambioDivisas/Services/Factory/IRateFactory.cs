using System.Collections.Generic;
using ExamenAlbertoMartinezCambioDivisas.Models;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Factory
{
    public interface IRateFactory
    {
        //List<Rates> ListaRates();
        //void CreateRate(Rates rate);
        List<Rates> CreateRatesList(List<Rates> ratesList);
    }
}
