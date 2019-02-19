using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceMVC.Models.Validations
{
    public class ValidarEstado : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var estado = (Estados)validationContext.ObjectInstance;

            if (estado.EstadoId != 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Debe seleccionar un estado");

        }

    }
}