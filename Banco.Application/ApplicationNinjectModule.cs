//------------------------------------------------------------------------------------------------
// <copyright file="ApplicationNinjectModule.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Application
{
    using Banco.Domain.IRepositories;
    using Banco.Infrastructure.DataPersistent.Repositories;
    using Ninject.Modules;

    /// <summary>
    /// Clase que se encarga de controla los modulos
    /// </summary>
    public class ApplicationNinjectModule : NinjectModule
    {
        /// <summary>
        /// Metodo que se encarga de cargar los modulos
        /// </summary>
        public override void Load()
        {
            ////Bind<IRepositoryLogin>().To<RepositoryLogin>();
        }
    }
}
