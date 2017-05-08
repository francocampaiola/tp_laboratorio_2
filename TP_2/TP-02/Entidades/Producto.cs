using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        EMarca _marca;
        string _codigoDeBarras;
        ConsoleColor _colorPrimarioEmpaque;

        public Producto(EMarca marca, string patente, ConsoleColor color)
        {
            this._marca = marca;
            this._codigoDeBarras = patente;
            this._colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.Append("CODIGO DE BARRAS: ");
            sb.AppendLine(this._codigoDeBarras);
            sb.Append("MARCA          : "); 
            sb.AppendLine(this._marca.ToString());
            sb.Append("COLOR EMPAQUE  : "); 
            sb.AppendLine(this._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            if (v1._codigoDeBarras == v2._codigoDeBarras)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            if (!(v1 == v2))
                return true;
            else
                return false;
        }
    }
}
