using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Snacks: Producto
    {
        protected EMarca _marca;
        protected int _cantCalorias;
        protected string _patente;
        protected ConsoleColor _color;

        public Snacks(EMarca marca, string patente, ConsoleColor color): base (marca, patente, color)
        {
            this._marca = marca;
            this._patente = patente;
            this._color = color;
            this._cantCalorias = 104;
        }
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        public int cantCalorias
        {
            get { return this._cantCalorias; }
        }

        public string MostrarSnack()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SNACKS");
            sb.AppendLine(this.Mostrar());
            sb.Append("CALORIAS: ");
            sb.AppendLine(this.cantCalorias.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
