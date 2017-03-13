using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using AutoMapper;
using BooksDataLayer;
using TeachMeArabic.Models;

namespace TeachMeArabic
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Handle self-referencing in EF
            var config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            // Convert to camelCase
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // AutoMapper config
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BookLevel, string>().ConvertUsing(bl => bl.ToString());
                cfg.CreateMap<Book, BookModel>();
            });
        }
    }
}
