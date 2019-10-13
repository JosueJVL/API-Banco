//------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Infrastructure.DataPersistent.DataObjects.Core
{
    using Banco.Domain.IRepositories;
    using Banco.Infrastructure.DataPersistent.DataObjects.Contracts;
    using Banco.Infrastructure.DataPersistent.Model;
    using Banco.Infrastructure.DataPersistent.Repositories;
    using System;
    using System.Threading.Tasks;
    using System.Transactions;

    /// <summary>
    /// Clase que se encarga de la unidad de trabajo
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Campo reservado para el contexto
        /// </summary>
        private readonly BancoModel context;

        /// <summary>
        /// Campo reservado para el scope de transacciones
        /// </summary>
        private TransactionScope transactionScope;

        /// <summary>
        /// Campo reservado para el disposable
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Repositorio de Login
        /// </summary>
        private IRepositoryLogin repositoryLogin;

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="context">Contexto del Modelo</param>
        public UnitOfWork(BancoModel context)
        {
            this.context = context;
        }

        /// <summary>
        /// Repositorio del Login
        /// </summary>
        public IRepositoryLogin RepositoryLogin
        {
            get
            {
                if (this.repositoryLogin == null)
                {
                    this.repositoryLogin = new RepositoryLogin(this.context);
                }

                return this.repositoryLogin;
            }
        }

        /// <summary>
        /// Método que se encarga de generar una transacción
        /// </summary>
        /// <param name="isolationLevel">Objeto que contiene el nivel de isolacion para la transacción</param>
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            this.transactionScope  = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions
                    {
                        IsolationLevel = isolationLevel,
                        Timeout = TransactionManager.MaximumTimeout
                    });
        }

        /// <summary>
        /// Disposable para liberar los recursos de la clase
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposable para liberar los recursos de la clase
        /// </summary>
        /// <param name="disposing">Bandera para liberar los recursos</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                    if (!object.Equals(null, this.transactionScope))
                    {
                        this.transactionScope.Dispose();
                    }
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Método que se encarga de completar la transacción
        /// </summary>
        public void Commit()
        {
            this.transactionScope.Complete();
        }

        /// <summary>
        /// Método que se encarga de reaizar el commit de la transacción
        /// </summary>
        public void SaveChange()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Método que se encarga de reaizar el commit de la transacción asincrona
        /// </summary>
        /// <returns>Retorna true si se realizo con exito, de lo contrario false</returns>
        public async Task<bool> SaveChangeAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}
