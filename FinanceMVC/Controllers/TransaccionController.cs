using System;
using System.Web.Mvc;

namespace FinanceMVC.Controllers
{
    [Authorize]
    public class TransaccionController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [Route("transaccion/producto/{producto}/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        public ActionResult TransaccionProductos(int producto, int year, int month){
            return Content( String.Format("Producto = {0} año = {1}  Mes = {2} ", producto, year, month) );
        }


    }
}