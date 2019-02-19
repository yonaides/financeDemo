using FinanceMVC.Models;
using FinanceMVC.ViewModel;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace FinancMVC.Controllers
{
    public class EstadosTarjetaController : Controller
    {
        private FinanceDbContext _context;


        public EstadosTarjetaController()
        {
            _context = new FinanceDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CompanyTarjetaCreditos company)
        {

            if (!ModelState.IsValid)
            {
                var viewMosdel = new CompanyTarjetaCreditoFormViewModel(company);
                return View("CompanyTarjetaCreditoForm", viewMosdel);
            }


            if (company.CompanyTarjetaCreditoId == 0)
            {
                _context.CompanyTarjetaCreditos.Add(company);
            }
            else
            {
                var companyTarjetaInDb = _context.CompanyTarjetaCreditos.Single(c => c.CompanyTarjetaCreditoId == company.CompanyTarjetaCreditoId);
                companyTarjetaInDb.CompanyTarjetaCreditoId = company.CompanyTarjetaCreditoId;
                companyTarjetaInDb.NombreCompany = company.NombreCompany;
                companyTarjetaInDb.EstadoId = company.EstadoId; 

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "CompanyTarjeta");
        }

        public ActionResult EstadoTarjetaForm()
        {
            var viewModel = new EstadoTarjetasViewModel();
            viewModel.ListadoProductos = _context.Productos.ToList();

            return View("EstadoTarjetaForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var company = _context.CompanyTarjetaCreditos.SingleOrDefault(c => c.CompanyTarjetaCreditoId == id);

            if (company == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CompanyTarjetaCreditoFormViewModel(company);

            return View("CompanyTarjetaForm", viewModel);

        }

        public ActionResult Listado()
        {

            var estadosTarjetas = _context.EstadoTarjetas.Include(a => a.Productos ).ToList();


            return View(estadosTarjetas);
        }

    }
}