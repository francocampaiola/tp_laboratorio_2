using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException: Exception
    {
        #region Constructores
        /// <summary>
        /// Lanza una excepción sobre un archivo.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            : base("No se puede acceder a este archivo", innerException)
        { }
        #endregion
    }
}
