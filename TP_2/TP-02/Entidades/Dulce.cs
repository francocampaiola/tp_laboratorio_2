using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Dulce: Producto
    {
        protected EMarca _marca;
        protected string _patente;
        protected ConsoleColor _color;
        protected int _cantCalorias;

        public Dulce(EMarca marca, string patente, ConsoleColor color): base (marca, patente, color)
        {
            this._patente = patente;
            this._color = color;
            this._marca = marca;
            this._cantCalorias = 80;
        }
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        public int cantCalorias
        {
            get { return this._cantCalorias; }
        }
        

        public string MostrarDulce()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("DULCE");
            sb.AppendLine(this.Mostrar());
            sb.Append("CALORIAS: ");
            sb.AppendLine(this.cantCalorias.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
