using System.Collections.Generic;
using ExamenAlbertoMartinezCambioDivisas.Models;

namespace ExamenAlbertoMartinezCambioDivisas.Services.MonedaConverter
{
    public class MonedaConversor : IMonedaConversor
    {
        public List<Rates> _ratesList;
        public void LoadRatesData(List<Rates> ratesList)
        {
            this._ratesList = ratesList;
        }

        public decimal ValueConverter(decimal value, string from, string to)
        {
            /* AQUI TENDRIAMOS QUE IMPLEMENTAR EL ALGORITMO DE DIJKSTRA PARA BUSCAR LOS DATOS Y CALCULAR EL VALOR */
            return value;
        }
    }
}