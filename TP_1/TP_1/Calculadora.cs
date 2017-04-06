using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    ///<summary>
    ///Clase Calculadora de la aplicación.
    ///</summary>
    ///<remarks>
    ///Contiene los métodos para limpiar y operar, recibiendo operandos y operadores. También contiene un método de validación del operador.
    ///</remarks>
    class Calculadora
    {
        public Calculadora calculadora;

        ///<summary>
        ///Limpia los números y operadores cargados en la interación anterior del programa. Recibe los dos objetos de tipo Número y un string.
        ///</summary>
        public static void Limpiar(Numero num1, Numero num2, string operador)
        {
            num1.cantidad = 0;
            num2.cantidad = 0;
            operador = "";
        }

        ///<summary>
        ///Opera en base al operador ingresado. Recibe dos objetos de tipo Número y un string.
        ///</summary>
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

        ///<summary>
        ///Valida que el operador sea válido. Recibe como parámetro un string.
        ///</summary>
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
