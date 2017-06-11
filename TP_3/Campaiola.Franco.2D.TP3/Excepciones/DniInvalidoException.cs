using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException: Exception
    {
        #region Atributos
        private static string _mensajeBase = "Numero de DNI invalido. Verifique.";
        #endregion

        #region Constructores
        /// <summary>
        /// Lanza una excepción sobre un DNI inválido.
        /// </summary>
        public DniInvalidoException()
            : base()
        { }

        /// <summary>
        /// Lanza una excepción sobre un DNI inválido con un mensaje base.
        /// </summary>
        /// <param name="e">Excepción</param>
        public DniInvalidoException(Exception e)
            : base(_mensajeBase, e)
        { }

        /// <summary>
        /// Lanza una excepción sobre un DNI inválido.
        /// </summary>
        /// <param name="message">Mensaje a incluir en la excepción</param>
        public DniInvalidoException(string message)
            : base(message)
        { }

        /// <summary>
        /// Lanza una excepción sobre un DNI inválido.
        /// </summary>
        /// <param name="e">Excepción</param>
        /// <param name="message">Mensaje a incluir en la excepción</param>
        public DniInvalidoException(Exception e, string message)
            : base(message, e)
        { }

        #endregion
    }
}
