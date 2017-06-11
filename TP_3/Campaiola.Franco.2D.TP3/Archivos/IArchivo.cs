using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        #region Firmas de métodos
        /// <summary>
        /// Guarda un archivo.
        /// </summary>
        /// <param name="archivo">Archivo a guardar</param>
        /// <param name="datos">Datos</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee un archivo.
        /// </summary>
        /// <param name="archivo">Archivo a leer</param>
        /// <param name="datos">Datos a exponer</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
        #endregion
    }
}
