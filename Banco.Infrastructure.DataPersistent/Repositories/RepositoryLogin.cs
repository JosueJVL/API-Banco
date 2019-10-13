//------------------------------------------------------------------------------------------------
// <copyright file="RepositoryLogin.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Infrastructure.DataPersistent.Repositories
{
    using Banco.Domain.Entity;
    using Banco.Domain.IRepositories;
    using Banco.Infrastructure.DataPersistent.DataObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Clase Repositorio de Login
    /// </summary>
    public class RepositoryLogin : GenericRepository<TB_USUARIOS>, IRepositoryLogin, IDisposable
    {
        /// <summary>
        /// Propiedad que contiene el contexto del modelo
        /// </summary>
        private readonly Model.BancoModel context;

        /// <summary>
        /// Propiedad reservada para el disposable
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Contructor de la Clase
        /// </summary>
        /// <param name="context">Instancia que contiene el contexto del Modelo</param>
        public RepositoryLogin(Model.BancoModel context)
            : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Metodo que obtine la informacion del Usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Retorna un usuario valido</returns>
        public UserModel GetUser(string username, string password)
        {
            return this.context.TB_USUARIOS.Where(c => c.USU_USUARIO.ToUpper() == username.ToUpper() 
            && c.USU_PASSWORD == password 
            && c.USU_ESTATUS == "true").Select(b => new UserModel { }).FirstOrDefault();
        }

        #region "IDisposable"
        /// <summary>
        /// Método que se encarga de liberar la memoria del GC
        /// </summary>
        /// <param name="disposing">Contiene el boleano para el dispose</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }

            this.disposed = true;
        }

        /// <summary>
        /// Método que se encarga de liberar el garbage collector
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
