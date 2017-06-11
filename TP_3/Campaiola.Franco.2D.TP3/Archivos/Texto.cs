using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Métodos
        public bool Guardar(string archivo, string datos)
        {
            bool retorno;

            try
            {
                using (StreamWriter wr = new StreamWriter(archivo))
                {
                    retorno = true;
                    wr.Write(datos);
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                throw new ArchivosException(ex);
            }

            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    retorno = true;
                    datos = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                retorno = false;
                throw new ArchivosException(ex);
            }

            return retorno;
        }
        #endregion
    }
}
