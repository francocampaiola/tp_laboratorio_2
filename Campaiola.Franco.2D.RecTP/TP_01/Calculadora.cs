using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_01
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            switch(operador)
            {
                case "+":
                    retorno = num1.GetNumero() + num2.GetNumero();
                    break;
                case "-":
                    retorno = num1.GetNumero() - num2.GetNumero();
                    break;
                case "*":
                    retorno = num1.GetNumero() * num2.GetNumero();
                    break;
                case "/":
                    if (num2.GetNumero() != 0)
                    {
                        retorno = num1.GetNumero() / num2.GetNumero();
                    }
                    else
                    {
                        retorno = 0;
                    }
                    break;
                default:
                    break;
            }

            return retorno;
        }

        public static string ValidarOperador(string operador)
        {
            string retorno = operador;

            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                retorno = "+";
            }

            return retorno;
        }
    }
}
