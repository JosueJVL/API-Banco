//------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryLogin.cs" company="Empresa S.A.">
//  Copyright (c) Empresa S.A., All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------

namespace Banco.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Modelo para los Usuarios
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Identificador del Usuario
        /// </summary>
        public int IdUser { get; set; }

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Rol del Usuario
        /// </summary>
        public string IdRol { get; set; }

        /// <summary>
        /// Status del Empleado
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Fecha de Creacion
        /// </summary>
        public Nullable<System.DateTime> CreationDate { get; set; }
    }
}
