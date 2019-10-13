//------------------------------------------------------------------------------------------------
// <copyright file="IServiceLogin.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Domain.IServices
{
    /// <summary>
    /// Contrato para el Servicio de Login
    /// </summary>
    public interface IServiceLogin
    {
        /// <summary>
        /// Metodo que valida los Usuarios
        /// </summary>
        /// <param name="username">Usario</param>
        /// <param name="password">Password</param>
        /// <returns>Retorna una cadena</returns>
        string GetUser(string username, string password);
    }
}
