using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    ///<summary>
    ///Clase número en la aplicación.
    ///</summary>
    ///<remarks>
    ///Recibe la cantidad del número y lo almacena en .cantidad, lo instancia y luego lo valida para notificar que sea válido. Además contiene un método privado que lo settea.
    ///</remarks>
    public class Numero
    {
        #region Número
        public double cantidad;
        #endregion

        #region Constructores

        ///<summary>
        ///Constructor del número sin parámetros a recibir.
        ///</summary>
        public Numero()
        {
            this.cantidad = 0;
        }

        ///<summary>
        ///Constructor del número recibiendo un double como parámetro.
        ///</summary>
        public Numero(double num)
        {
            this.cantidad = num;
        }

        ///<summary>
        ///Constructor del número recibiendo un string como parámetro.
        ///</summary>
        public Numero(string numStr)
        {
            if (validarNumero(numStr) != 0)
            {
                this.cantidad = double.Parse(numStr);
            }
        }
        #endregion

        ///<summary>
        ///Valida el número recibiendo un string y devolviendo un double.
        ///</summary>
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

        ///<summary>
        ///Método privado que "settea" el número recibiendo un string como parámetro.
        ///</summary>
        private void setNumero(string num)
        {
            this.cantidad = double.Parse(num);
        }
    }
}
