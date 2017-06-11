using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno: Universitario
    {
        #region Atributos

        private EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa un alumno.
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalida del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Inicializa un alumno.
        /// </summary>
        /// <param name="id">ID del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalida del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Muestra los datos de un alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta: " + this._estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Hace participar en la clase a un alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "Toma clase de: " + this._claseQueToma.ToString();
        }

        #endregion

        #region Polimorfismo ToString

        /// <summary>
        /// Retorna los datos del alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Evalúa si un alumno y una clase son iguales mediante si el alumno participa en tal clase.
        /// </summary>
        /// <param name="a">Alumno a evaluar</param>
        /// <param name="clase">Clase a evaluar</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool retorno = false;
            if (a._claseQueToma.Equals(clase))
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Evalúa si un alumno no se encuentra en una clase.
        /// </summary>
        /// <param name="a">Alumno a evaluar</param>
        /// <param name="clase">Clase a evaluar</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a == clase);
        }

        #endregion
    }
}
