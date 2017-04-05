using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    class Calculadora
    {
        public Calculadora calculadora; 

        public static void Limpiar(Numero num1, Numero num2, string operador)
        {
            num1.cantidad = 0;
            num2.cantidad = 0;
            operador = "";
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
           switch (operador)
            { 
                case "+":
                    double suma = num1.cantidad + num2.cantidad;
                    return suma;
                case "-":
                    double resta = num1.cantidad - num2.cantidad;
                    return resta;
                case "*":
                    double multi = num1.cantidad * num2.cantidad;
                    return multi;
                case "/":
                    if (num2.cantidad != 0)
                    {
                        double divi = num1.cantidad / num2.cantidad;
                        return divi;
                    }
                    else
                    {
                        return 0;
                    }
                default:
                   {
                      return 0;
                   }
            }
        }

        public static string validarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "";
            }
        }
    }
}
