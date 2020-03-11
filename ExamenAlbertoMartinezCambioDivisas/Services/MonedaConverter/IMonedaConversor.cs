using System.Collections.Generic;
using ExamenAlbertoMartinezCambioDivisas.Models;

namespace ExamenAlbertoMartinezCambioDivisas.Services.MonedaConverter
{
    public interface IMonedaConversor
    {
        void LoadRatesData(List<Rates> ratesList);
        decimal ValueConverter(decimal value, string from, string to);
    }
}
