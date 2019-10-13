//------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Infrastructure.DataPersistent.DataObjects.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface que contiene las declaraciones del Repositorio
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Metodo que se encarga de obtener un tabla
        /// </summary>
        /// <typeparam name="T">Objeto generico que define a una entidad</typeparam>
        /// <returns>Retorna un enamerable de la entidad</returns>
        IEnumerable<T> GetTable<T>() where T : class;
    }
}
