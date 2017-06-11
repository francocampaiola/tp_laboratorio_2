using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException: Exception
    {
        #region Constructores
        /// <summary>
        /// Lanza una excepción sobre una clase sin profesor.
        /// </summary>
        public SinProfesorException()
            : base("No existe un profesor disponible para la clase.")
        { }
        #endregion
    }
}
