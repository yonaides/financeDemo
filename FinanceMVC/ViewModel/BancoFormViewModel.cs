using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FinanceMVC.Models;

namespace FinanceMVC.ViewModel
{
    public class BancoFormViewModel
    {

        public BancoFormViewModel()
        {
            Productos = new HashSet<Productos>();
        }

        public int BancoId { get; set; }

        [Required (ErrorMessage ="Escriba el nombre del banco")]
        [StringLength(200)]
        [Display(Name = "Nombre del Banco")]
        public string NombreBanco { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }

        public string Titulo
        {
            get
            {
                return BancoId != 0 ? "Editando Banco" : "Nuevo Banco";
            }
        }

        public BancoFormViewModel(Bancos banco)
        {
            BancoId = banco.BancoId;
            NombreBanco = banco.NombreBanco;
            
        }

    }
}