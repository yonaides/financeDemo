using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanceMVC.Models;
using FinanceMVC.ViewModel;

namespace FinanceMVC.Controllers
{
    [Authorize]
    public class BancoController : Controller
    {
        private FinanceDbContext _context;


        public BancoController()
        {
            _context = new FinanceDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult BancoForm()
        {
            var viewModel = new BancoFormViewModel();
            
            return View("BancoForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Bancos banco)
        {

            if (!ModelState.IsValid)
            {
                var viewMosdel = new BancoFormViewModel(banco);
                return View("BancoForm", viewMosdel);
            }


            if (banco.BancoId == 0)
            {
                _context.Bancos.Add(banco);
            }
            else
            {
                var bancoInDb = _context.Bancos.Single(c => c.BancoId == banco.BancoId);
                bancoInDb.BancoId = banco.BancoId; 
                bancoInDb.NombreBanco = banco.NombreBanco;
                
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Banco");
        }


        public ActionResult Edit(int id)
        {
            var banco = _context.Bancos.SingleOrDefault(c => c.BancoId == id);

            if (banco == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BancoFormViewModel(banco);
             
            return View("BancoForm", viewModel);

        }

        
        public ActionResult Index(int? indexPage, string sortBy)
        {
            var banco = _context.Bancos.ToList();
            return View(banco);
        }

    }
}