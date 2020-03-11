using System.ComponentModel.DataAnnotations;

namespace ExamenAlbertoMartinezCambioDivisas.Models.ViewModel
{
    public class ListadoPorSkuVM
    {
        [Key]
        public string Sku { get; set; }
        public decimal SumaAmounts { get; set; }
        public string Moneda { get; set; }
    }
}