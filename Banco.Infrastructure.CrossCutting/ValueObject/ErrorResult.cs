//------------------------------------------------------------------------------------------------
// <copyright file="ErrorResult.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Infrastructure.CrossCutting.ValueObject
{
    /// <summary>
    /// Clase para devolver errores no controlados dentro del API
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Indica si este mensaje es un error no contrado <see cref="ErrorResult"/>
        /// </summary>
        public bool Error { get; set; }

        /// <summary>
        /// Mensaje para mostrar al usuario
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Llanar aqui el detalle de la excepcion, solo para depuracion
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Llanar aqui el trace de la excepcion, solo para depuracion
        /// </summary>
        public string Stacktrace { get; set; }
    }
}
