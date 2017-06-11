using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario: Persona
    {
        #region Atributos

        private int _legajo;

        #endregion

        #region Métodos

        /// <summary>
        /// Muestra los datos de un Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append("Legajo: " + this._legajo);
            sb.AppendLine("");
            return sb.ToString();
        }

        /// <summary>
        /// Hace participar en la clase a un Universitario.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa un universitario.
        /// </summary>
        public Universitario(): base() { }

        /// <summary>
        /// Inicializa un universitario con parámetros.
        /// </summary>
        /// <param name="legajo">Legajo del universitario</param>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">DNI del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Verifica si dos universitarios son iguales o no mediante su legajo y su DNI.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1._legajo == pg2._legajo || pg1.Dni == pg2.Dni)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifica si dos universitarios no son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        #region Polimorfismo Equals

        /// <summary>
        /// Evalúa si un universitario es verdaderamente un universitario.
        /// </summary>
        /// <param name="obj">Objeto a recibir</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is Universitario)
            {
                Universitario u = (Universitario)obj;

                if (this.Dni == u.Dni || this._legajo == u._legajo)
                    retorno = true;               
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        #endregion
    }
}
