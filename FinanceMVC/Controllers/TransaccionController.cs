using FinanceMVC.Models;
using System;
using System.Web.Mvc;

namespace FinanceMVC.Controllers
{
    [AllowAnonymous]
    public class TransaccionController : Controller
    {

        private FinanceDbContext _context;

        public TransaccionController()
        {
            _context = new FinanceDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            return View();
        }

        [Route("transaccion/producto/{producto}/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        public ActionResult TransaccionProductos(int producto, int year, int month){
            return Content( String.Format("Producto = {0} año = {1}  Mes = {2} ", producto, year, month) );
        }

        [HttpPost]
        public ActionResult save()
        {

            return RedirectToAction("Index", "Producto");

        }

    }
}