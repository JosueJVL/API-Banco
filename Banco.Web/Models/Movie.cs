using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Web.Models
{
    public class Movie
    {
        /// <summary>
        /// Titulo de la Pelicula
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Dia del Estreño
        /// </summary>
        public DateTime RelaseDate { get; set; } 
    }
}
