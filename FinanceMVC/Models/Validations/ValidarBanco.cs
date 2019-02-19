using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceMVC.Models.Validations
{
    public class ValidarBanco : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var producto = (Productos)validationContext.ObjectInstance;

            if (producto.BancoId != 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Debe seleccionar un banco");


        }
    }
}