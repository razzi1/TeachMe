using AutoMapper;
using BooksDataLayer;
using BooksDataLayer.Entities;
using Newtonsoft.Json.Serialization;
using Repository;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
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

            // Dependency injection
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IDbConctext, BookContext>(Lifestyle.Scoped);
            container.Register<IRepository<Author>, Repository<Author>>(Lifestyle.Scoped);
            container.Register<IRepository<Book>, Repository<Book>>(Lifestyle.Scoped);
            container.Register<IRepository<BookType>, Repository<BookType>>(Lifestyle.Scoped);
            container.Register<IRepository<Language>, Repository<Language>>(Lifestyle.Scoped);
            container.Register<IRepository<Parent>, Repository<Parent>>(Lifestyle.Scoped);
            container.Register<IRepository<Publisher>, Repository<Publisher>>(Lifestyle.Scoped);
            container.Register<IRepository<Student>, Repository<Student>>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
