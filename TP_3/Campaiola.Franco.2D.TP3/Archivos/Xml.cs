using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {
        #region Métodos
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                { 
                    XmlSerializer ser = new XmlSerializer((typeof(T)));
                    ser.Serialize(writer, datos);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
                throw new ArchivosException(e);
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(T));
                TextReader writer = new StreamReader(archivo);

                datos = (T)sr.Deserialize(writer);
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = default(T);
                return false; 
            }
        }
        #endregion
    }
}
