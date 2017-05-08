using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche: Producto
    {
        public enum ETipo { Entera, Descremada }
        protected ETipo _tipo;
        protected EMarca _marca;
        protected int _cantCalorias;
        protected string _patente;
        protected ConsoleColor _color;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        public Leche(EMarca marca, string patente, ConsoleColor color): base (marca, patente, color)
        {
            this._marca = marca;
            this._patente = patente;
            this._color = color;
            this._tipo = ETipo.Entera;
            this._cantCalorias = 20;
        }

        /// <summary>
        /// Constructor con sobrecarga
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="tipo"></param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo): base (marca, patente, color)
        {
            this._marca = marca;
            this._patente = patente;
            this._color = color;
            this._tipo = tipo;
            this._cantCalorias = 20;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public int cantCalorias
        {
            get
            {
               return this._cantCalorias;
            }
        }

        public string MostrarLeche()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("LECHE");
            sb.AppendLine(this.Mostrar());
            sb.Append("CALORIAS: ");
            sb.AppendLine(this.cantCalorias.ToString());
            sb.AppendLine("TIPO: " + this._tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
