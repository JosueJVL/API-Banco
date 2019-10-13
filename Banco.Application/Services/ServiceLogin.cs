//------------------------------------------------------------------------------------------------
// <copyright file="ServiceLogin.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Application.Services
{
    using Banco.Domain.Entity;
    using Banco.Domain.IRepositories;
    using Banco.Domain.IServices;
    using Banco.Infrastructure.DataPersistent.DataObjects.Contracts;
    using Banco.Infrastructure.DataPersistent.DataObjects.Core;
    using Banco.Infrastructure.DataPersistent.Model;
    using System.Linq;

    /// <summary>
    /// Clase que se encarga del servicio del Login
    /// </summary>
    public class ServiceLogin : IServiceLogin
    {
        /////// <summary>
        /////// Campo solo de lectura para la Interfaz del Repositorio de Login
        /////// </summary>
        ////private readonly IRepositoryLogin repositoryLogin;

        /////// <summary>
        /////// Constructor de la Clase
        /////// </summary>
        ////public ServiceLogin(IRepositoryLogin repositoryLogin)
        ////{
        ////    this.repositoryLogin = repositoryLogin;
        ////}

        /// <summary>
        /// Metodo que obtiene a los Usuarios
        /// Obtiene el Usario 
        /// </summary>
        /// <param name="username">Usuario</param>
        /// <param name="password">Contraseña del Usuario</param>
        /// <returns>Retorna una candena de caracteres</returns>
        public string GetUser(string username, string password)
        {
            if(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return null;
            }

            using (IUnitOfWork unit = new UnitOfWork(new BancoModel()))
            {
                var user = unit.RepositoryLogin.GetUser(username, password);
                if (user == null)
                {
                    return null;
                }
            }

            return "No se encontraron el Usuario";
        }
    }
}
