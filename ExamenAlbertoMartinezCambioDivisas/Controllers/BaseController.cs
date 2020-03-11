using System.Web.Mvc;
using ExamenAlbertoMartinezCambioDivisas.Services.Log;

namespace ExamenAlbertoMartinezCambioDivisas.Controllers
{
    public class BaseController : Controller
    {
        private ILog log;
        protected override void OnException(ExceptionContext filterContext)
        {
            this.log = new LogTxt();

            if (filterContext.ExceptionHandled)
            {
                return;

            }

            this.log.WriteLog(filterContext.Exception.Message);

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}