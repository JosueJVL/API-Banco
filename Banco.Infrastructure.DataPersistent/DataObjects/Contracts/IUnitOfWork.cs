//------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Infrastructure.DataPersistent.DataObjects.Contracts
{
    using Banco.Domain.IRepositories;
    using System;
    using System.Threading.Tasks;
    using System.Transactions;

    public interface IUnitOfWork: IDisposable
    {
        /// <summary>
        /// Repositorio de Login
        /// </summary>
        IRepositoryLogin RepositoryLogin { get; }

        /// <summary>
        /// Metodo que se encarga de realizar el commit de la transaccion
        /// </summary>
        void SaveChange();

        /// <summary>
        /// Metodo que se encarga de realizar el commit de la Transaccion asincrona
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangeAsync();

        /// <summary>
        /// Método que se encarga de completar la transacción
        /// </summary>
        void Commit();

        /// <summary>
        /// Método que se encarga de generar una transacción
        /// </summary>
        /// <param name="isolationLevel">Objeto que contiene el nivel de isolacion para la transacción</param>
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
    }
}
