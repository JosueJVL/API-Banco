//------------------------------------------------------------------------------------------------
// <copyright file="LoginController.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.API.Controllers
{
    using Banco.Domain.IServices;
    using System.Web.Http;
    using System.Web.Http.Description;

    public class LoginController : ApiController
    {
        /// <summary>
        /// Propiedad solo de lectura para almacenar la Instancia del Servicio
        /// </summary>
        private readonly IServiceLogin _serviceLogin;
        
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="serviceLogin"></param>
        public LoginController(IServiceLogin serviceLogin)
        {
            this._serviceLogin = serviceLogin;
        }

        /// <summary>
        /// Metodo que valida el Usario y Contraseña
        /// </summary>
        /// <param name="username">Usuario a Validar</param>
        /// <param name="password">Contraseña a Validar</param>
        /// <returns>Bandera que indica si es usuario es correcto</returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult Get(string username, string password)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return this.Ok(this._serviceLogin.GetUser(username, password));
            }

            this._serviceLogin.GetUser(username, password);

            return this.Ok("Value");
        }
    }
}