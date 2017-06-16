using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {       
        string archivo;
        string path = "../../../";

        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path + archivo, true);
                sw.WriteLine(datos.ToString(), Encoding.UTF8);
                sw.Close();
                return true;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message + "- El archivo no pudo ser guardado.");
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(path + archivo, Encoding.UTF8);

                while (!sr.EndOfStream)
                {
                    datos.Add(sr.ReadLine());
                }

                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "- El archivo no pudo ser leído.");
            }
        }
    }
}
