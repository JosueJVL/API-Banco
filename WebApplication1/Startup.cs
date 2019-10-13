using System.Web.Http;
using Owin;
using WebApplication1.DI;

//[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            
            // Agrega las cabeceras CORS
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var ioc = new IoC();
            var kernel = ioc.Kernel;

            config.MapHttpAttributeRoutes();

            //Agrega la configuracion de Web.API
            app.UseWebApi(config);
        }
    }
}