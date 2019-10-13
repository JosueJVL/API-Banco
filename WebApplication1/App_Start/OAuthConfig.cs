using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApplication1.App_Start
{
    public partial class Startupw
    {

        /// <summary>
        /// Metodo que configura las opciones de Autenticación
        /// </summary>
        /// <param name="app">Instacia de aplicación de OWIN</param>
        /// <param name="kernel">Kernel de ninject</param>
        public void ConfigureOAuth(IAppBuilder app, IKernel kernel)
        {
            var https = bool.Parse(ConfigurationManager.AppSettings["AllowInsecureHttp"]);
            var issuer = HttpContext.Current.Request.Url.Host;
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["SymmetricKey"]);
        }
    }
}