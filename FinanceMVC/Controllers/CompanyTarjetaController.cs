using FinanceMVC.Models;
using FinanceMVC.ViewModel;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace FinanceMVC.Controllers
{
    public class CompanyTarjetaController : Controller
    {
        private FinanceDbContext _context;


        public CompanyTarjetaController()
        {
            _context = new FinanceDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult CompanyTarjetaForm()
        {
            var viewModel = new CompanyTarjetaCreditoFormViewModel()
            {
                ListadoEstados = _context.Estados.ToList()
            };

            return View("CompanyTarjetaForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CompanyTarjetaCreditos company)
        {

            if (!ModelState.IsValid)
            {
                var viewMosdel = new CompanyTarjetaCreditoFormViewModel(company)
                {
                    ListadoEstados = _context.Estados.ToList()
                };

                return View("CompanyTarjetaForm", viewMosdel);
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

        public ActionResult Edit(int id)
        {
            var company = _context.CompanyTarjetaCreditos.SingleOrDefault(c => c.CompanyTarjetaCreditoId == id);

            if (company == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CompanyTarjetaCreditoFormViewModel(company)
            {
                ListadoEstados = _context.Estados.ToList()
            };

            return View("CompanyTarjetaForm", viewModel);

        }


        // GET: CompanyTarjeta
        public ActionResult Index()
        {
            var tarjetaCredito = _context.CompanyTarjetaCreditos.Include( a => a.Estados).ToList();
            return View(tarjetaCredito);
            
        }
    }
}