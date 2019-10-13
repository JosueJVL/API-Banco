//------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace WebApplication1.DI
{
    using Banco.Application;
    using CommonServiceLocator.NinjectAdapter.Unofficial;
    using Microsoft.Practices.ServiceLocation;
    using Ninject;

    /// <summary>
    /// Clase IoC 
    /// </summary>
    public class IoC
    {
        /// <summary>
        /// Constructor que genera la instancia de la clase <see cref="IoC"/>
        /// </summary>
        public IoC()
        {
            this.Kernel = this.GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(this.Kernel));
        }

        /// <summary>
        /// Proporciona el kernel
        /// </summary>
        public IKernel Kernel { get; private set; }

        /// <summary>
        /// Método que se encarga de aplicar los modulos
        /// </summary>
        /// <returns>Retorna el kernel de los modulos inyectados</returns>
        public StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ApiNinjectModule(),
                new ApplicationNinjectModule());
        }
    }
}