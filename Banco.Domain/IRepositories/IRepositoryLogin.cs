//------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryLogin.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Domain.IRepositories
{

    using Banco.Domain.Entity;

    /// <summary>
    /// Interface que contiene la definicion del repositorio Usuarios
    /// </summary>
    public interface IRepositoryLogin : IGenericRepository<TB_USUARIOS>
    {
        /// <summary>
        /// Metodo que obtiene los usuarios
        /// </summary>
        /// <param name="username">Usuario</param>
        /// <param name="password">Conyraseña</param>
        /// <returns>Retorna una cadena</returns>
        UserModel GetUser(string username, string password);
    }
}
