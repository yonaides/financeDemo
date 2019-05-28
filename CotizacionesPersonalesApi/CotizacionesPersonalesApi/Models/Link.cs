using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Models
{
    [NotMapped]
    public class Link
    {
        public const string GetMethod = "GET";

        public static Link To(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = null
            };

        public static Link ToCollection(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = new[] {"collection"}
            };

        [JsonProperty(Order = -4)]
        public string Href { get; set; }

        [JsonProperty(Order = -3, PropertyName="rel", NullValueHandling = NullValueHandling.Ignore)]
        [NotMapped]
        public string[] Relations { get; set; }

        [JsonProperty(Order = -2, DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(GetMethod)]
        public string Method { get; set; }

        // store the route name
        [JsonIgnore]
        public string RouteName { get; set; }

        // store the route parameter
        [JsonIgnore]
        [NotMapped]
        public object RouteValues { get; set; }


    }
}
