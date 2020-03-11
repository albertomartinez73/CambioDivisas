using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ExamenAlbertoMartinezCambioDivisas.Services.Repository.RatesRepository;
using ExamenAlbertoMartinezCambioDivisas.Services.Repository.TransactionsRepository;

namespace ExamenAlbertoMartinezCambioDivisas.Controllers.Consultas
{
    public class ListadoPorSkuController : BaseController
    {
        private IRatesRepository ratesRespository;
        private ITransactionsRepository transactionsRepository;

        public ListadoPorSkuController()
        {
            this.ratesRespository = new RatesRepository();
            this.transactionsRepository = new TransactionsRepository();
        }

        public ListadoPorSkuController(IRatesRepository ratesRespository, ITransactionsRepository transactionsRepository)
        {
            this.ratesRespository = ratesRespository;
            this.transactionsRepository = transactionsRepository;
        }
        // GET: ListadoPorSku
        public async Task<ActionResult> Index()
        {
            await this.ratesRespository.LoadData();
            await this.transactionsRepository.LoadData();

            var query = this.transactionsRepository.ListadoSku();
            return View( query);
        }

        public ActionResult VerTransacciones(string sku)
        {
            
            var query = this.transactionsRepository.TransactionsPorSku(sku);
            return View(query.ToList());
        }
    }
}