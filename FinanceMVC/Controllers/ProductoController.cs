using FinanceMVC.Models;
using FinanceMVC.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FinanceMVC.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {
        private FinanceDbContext _context;

        public ProductoController()
        {
            _context = new FinanceDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageProductos)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductoForm()
        {
            var viewModel = new ProductoFormViewModel()
            {
                ListadoCompanyTarjetasCreditos = _context.CompanyTarjetaCreditos.ToList(),
                ListadoBancos = _context.Bancos.ToList()

            };

            return View("ProductoForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageProductos)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Productos producto)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new ProductoFormViewModel(producto)
                {

                    ListadoBancos = _context.Bancos.ToList(),
                    ListadoCompanyTarjetasCreditos = _context.CompanyTarjetaCreditos.ToList()
                };

                return View("ProductoForm", viewModel);
            }


            if (producto.ProductoId == 0)
            {
                producto.UsuarioId = 1; // debo cambiar este magic number
                _context.Productos.Add(producto);
            }
            else
            {
                var productoInDb = _context.Productos.Single(c => c.ProductoId == producto.ProductoId);
                productoInDb.Nombre = producto.Nombre;
                productoInDb.Numero = producto.Numero;
                productoInDb.LimiteCredito = producto.LimiteCredito;
                productoInDb.LimiteCreditoDollar = producto.LimiteCreditoDollar;
                productoInDb.DiaVencimiento = producto.DiaVencimiento;
                productoInDb.BancoId = producto.BancoId;
                productoInDb.CompaniaTarjetaCreditoId = producto.CompaniaTarjetaCreditoId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Producto");
        }


        public ActionResult Edit(int id)
        {
            var producto = _context.Productos.SingleOrDefault(c => c.ProductoId == id);

            if (producto == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProductoFormViewModel(producto)
            {

                ListadoBancos = _context.Bancos.ToList(),
                ListadoCompanyTarjetasCreditos = _context.CompanyTarjetaCreditos.ToList()

            };

            return View("ProductoForm", viewModel);

        }


        // GET: Producto
        public ViewResult Index()
        {
            var producto = _context.Productos.Include(a => a.Bancos).Include(b => b.CompanyTarjetaCreditos).ToList();

            if (User.IsInRole(RoleName.Guest))
            {
                return View("ReadOnlyIndex",producto);
            }
            return View(producto);

        }

        public ActionResult Detalles(int id)
        {
            var producto = _context.Productos.Include(p => p.EstadoTarjetas).FirstOrDefault(a => a.ProductoId == id);

            if (producto == null)
                return HttpNotFound();

            return View(producto);

        }

    }
}