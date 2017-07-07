using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";

        /// <summary>
        /// Guarda un archivo XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTW = new XmlTextWriter(this.path + archivo, UTF8Encoding.UTF8);
                xmls.Serialize(xmlTW, datos);
                xmlTW.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Lee un archivo XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(T));
                XmlTextReader xmlRD = new XmlTextReader(path + archivo);
                datos = (T)sr.Deserialize(xmlRD);
                xmlRD.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = default(T);
                return false; 
            }
        }
    }
}
