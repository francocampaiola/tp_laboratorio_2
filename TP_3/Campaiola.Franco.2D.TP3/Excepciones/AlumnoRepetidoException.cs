using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException: Exception
    {
        #region Constructores
        /// <summary>
        /// Lanza una excepción sobre un alumno repetido.
        /// </summary>
        public AlumnoRepetidoException(): base ("Alumno repetido")
        { }
        #endregion
    }
}
