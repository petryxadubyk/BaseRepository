using System.Web.Http;
using System.Web.Http.Validation.Providers;
using Newtonsoft.Json.Serialization;

namespace KRS.WebApi
{
    public static class GlobalConfig
    {
        public static void CustomizeConfig(HttpConfiguration config)
        {
            // Remove Xml formatters. This means when we visit an endpoint from a browser,
            // Instead of returning Xml, it will return Json.
            // More information from Dave Ward: http://jpapa.me/P4vdx6
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Configure json camelCasing per the following post: http://jpapa.me/NqC2HH
            // Here we configure it to write JSON property names with camel casing
            // without changing our server-side data model:
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();


            //config.Services.RemoveAll(
              //  typeof(System.Web.Http.Validation.ModelValidatorProvider),
                //v => v is InvalidModelValidatorProvider);

            // Add model validation, globally
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}