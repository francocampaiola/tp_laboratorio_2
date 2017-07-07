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
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";

        /// <summary>
        /// Guarda un archivo de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter(this.path + archivo, true))
                {
                    wr.WriteLine(datos);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Lee un archivo de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader reader = new StreamReader(this.path + archivo))
                {
                    datos = reader.ReadToEnd();
                }
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                datos = "";
                return false;
            }
        }
    }
}
