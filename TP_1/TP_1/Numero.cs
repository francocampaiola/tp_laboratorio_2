using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    public class Numero
    {
        #region Número
        public double cantidad;
        #endregion

        #region Constructores
        public Numero()
        {
            this.cantidad = 0;
        }

        public Numero(double num)
        {
            this.cantidad = num;
        }

        public Numero(string numStr)
        {
            if (validarNumero(numStr) != 0)
            {
                this.cantidad = double.Parse(numStr);
            }
        }
        #endregion

        private static double validarNumero(string numeroString)
        {
            if (double.Parse(numeroString) != 0)
            {
                return double.Parse(numeroString);
            }
            else
            {
                return 0;
            }
        }

        private void setNumero(string num)
        {
            this.cantidad = double.Parse(num);
        }
    }
}
