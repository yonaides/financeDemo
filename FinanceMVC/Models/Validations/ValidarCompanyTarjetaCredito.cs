using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinanceMVC.Models.Validations 
{
    public class ValidarCompanyTarjetaCredito : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var producto = (Productos)validationContext.ObjectInstance;
             
            if ( producto.CompaniaTarjetaCreditoId != 0 )
            {
                return ValidationResult.Success;
            } 

            return new ValidationResult("Debe seleccionar una compañia de tarjeta de credito");
            
        }
    }
}