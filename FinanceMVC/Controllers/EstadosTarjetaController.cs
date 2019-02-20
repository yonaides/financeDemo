using FinanceMVC.Models;
using FinanceMVC.ViewModel;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System;

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
        public ActionResult Save(EstadoTarjetas estadoTarjeta)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new EstadoTarjetasViewModel(estadoTarjeta)
                {
                    ListadoProductos = _context.Productos.ToList()
                    
                };
                return View("EstadoTarjetaForm", viewModel);
            }

            if (estadoTarjeta.EstadoTarjetaId == 0)
            {
                estadoTarjeta.FechaCreacion = DateTime.Now;
                _context.EstadoTarjetas.Add(estadoTarjeta);
            }
            else
            {
                var estadoTarjetaInDb = _context.EstadoTarjetas.Single(c => c.EstadoTarjetaId == estadoTarjeta.EstadoTarjetaId);
                estadoTarjetaInDb.BalancePendiente = estadoTarjeta.BalancePendiente;
                estadoTarjetaInDb.FechaVencimiento = estadoTarjeta.FechaVencimiento;
                estadoTarjetaInDb.ProductosId = estadoTarjeta.ProductosId;
                
            }

            _context.SaveChanges();

            return RedirectToAction("Listado", "EstadosTarjeta");


        }

        public ActionResult EstadoTarjetaForm()
        {
            var viewModel = new EstadoTarjetasViewModel();
            viewModel.ListadoProductos = _context.Productos.ToList();

            return View("EstadoTarjetaForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var estadosTarjeta = _context.EstadoTarjetas.SingleOrDefault(c => c.EstadoTarjetaId == id);
            if (estadosTarjeta == null)
            {
                return HttpNotFound();
            }


            var viewModel = new EstadoTarjetasViewModel(estadosTarjeta)
            {
                ListadoProductos = _context.Productos.ToList()
            };

            return View("EstadoTarjetaForm", viewModel);

        }

        public ActionResult Listado()
        {
            var estadosTarjetas = _context.EstadoTarjetas.Include(a => a.Productos ).ToList();
            return View(estadosTarjetas);
        }

    }
}