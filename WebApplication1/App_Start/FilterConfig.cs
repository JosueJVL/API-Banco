//------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------


namespace WebApplication1
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;

    /// <summary>
    /// Clase de FilterConfig
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Metodo que configura los filtros del Web.API 
        /// Este metodo se utiliza para la configuracion de autentification para la aplicacion
        /// </summary>
        /// <param name="config">Objeto de configuracion de Web.API</param>
        public static void Configure(HttpConfiguration config)
        {
            ////config.Filters.Add(new System.Web.Http.AuthorizeAttribute());
        }

        /// <summary>
        /// Metodo de GlobalFilter
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
