using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.AutoMapper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SortableAttribute : Attribute
    {

        public string Name { get; set; }
        public bool Desceding { get; set; }
        public bool Default { get; set; }
    }

}
