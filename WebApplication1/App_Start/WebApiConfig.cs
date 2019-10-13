//------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    /// <summary>
    /// Clase del WebConfig
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiRoute",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
