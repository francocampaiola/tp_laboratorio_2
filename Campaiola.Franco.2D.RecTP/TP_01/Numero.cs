using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_01
{
    public class Numero
    {
        protected double _numero;

        public Numero()
        {
            this._numero = 0;
        }

        public Numero(double num)
        {
            this._numero = num;
        }

        public Numero(string num)
        {
            SetNumero(num);
        }

        public double GetNumero()
        {
            return this._numero;
        }

        private void SetNumero(string num)
        {
            this._numero = ValidarNumero(num);
        }

        private double ValidarNumero(string num)
        {
            double retorno = 0;
            double.TryParse(num, out retorno);
            return retorno;
        }
    }
}
