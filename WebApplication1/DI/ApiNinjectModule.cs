//------------------------------------------------------------------------------------------------
// <copyright file="ApiNinjectModule.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace WebApplication1.DI
{
    using Banco.Application.Services;
    using Banco.Domain.IServices;
    using Ninject.Modules;

    /// <summary>
    /// Clas de NijectModule carga de modulos
    /// </summary>
    public class ApiNinjectModule: NinjectModule
    {
        /// <summary>
        /// Metodo que se encarga de cargar las interfaces
        /// </summary>
        public override void Load()
        {
            Bind<IServiceLogin>().To<ServiceLogin>();
        }
    }
}