using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    [Serializable]
    public sealed class Alumno: Universitario
    {
        #region Atributos
        private EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region Constructores
        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra los datos de un Alumno.
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
        /// Permite hacer "participar en clase" a un Alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "Toma clase de: " + this._claseQueToma.ToString();
        }

        /// <summary>
        /// Polimorfismo ToString. Muestra datos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool retorno = false;
            if (a._claseQueToma.Equals(clase))
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a == clase);
        }
        #endregion
    }
}
