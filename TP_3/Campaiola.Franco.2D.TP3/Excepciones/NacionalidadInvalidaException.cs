using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException: Exception
    {
        #region Constructores
        /// <summary>
        /// Lanza una excepción sobre una nacionalidad inválida.
        /// </summary>
        public NacionalidadInvalidaException()
            : base("La nacionalidad no coincide en condiciones con el número de DNI.")
        { }

        /// <summary>
        /// Lanza una excepción sobre una nacionalidad inválida con cierto mensaje.
        /// </summary>
        /// <param name="message">Mensaje a incluir en la excepción</param>
        public NacionalidadInvalidaException(string message)
            : base(message)
        { }
        #endregion
    }
}
