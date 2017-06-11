using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    #region Serialización

    [Serializable]

    #endregion

    public sealed class Profesor: Universitario
    {
        #region Atributos

        private Queue<EClases> _claseDelDia;
        private static Random _random;

        #endregion

        #region Métodos

        /// <summary>
        /// Genera dos clases random para el profesor.
        /// </summary>
        private void _randomClases()
        {
            this._claseDelDia.Enqueue((EClases)_random.Next(0, 4));
            this._claseDelDia.Enqueue((EClases)_random.Next(0, 4));
        }

        /// <summary>
        /// Retorna los datos de un profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Retorna las clases en las que participa ese profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");

            foreach (EClases aux in this._claseDelDia)
            {
                sb.AppendLine(aux.ToString());
            }

            return sb.ToString();
        }

        #endregion

        #region Polimorfismo ToString

        /// <summary>
        /// Retorna los datos del profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa un atributo random para las clases del profesor.
        /// </summary>
        static Profesor()
        {
           _random = new Random();
        }

        /// <summary>
        /// Inicializa un profesor.
        /// </summary>
        public Profesor()
        { }

        /// <summary>
        /// Inicializa un profesor con parámetros.
        /// </summary>
        /// <param name="id">ID del profesor</param>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <param name="dni">DNI del profesor</param>
        /// <param name="nacionalidad">Nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseDelDia = new Queue<EClases>();
            this._randomClases();
        }

        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Evalúa si un profesor da una clase.
        /// </summary>
        /// <param name="i">Profesor a evaluar</param>
        /// <param name="clase">Clase a evaluar</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool retorno = false;
            foreach (EClases aux in i._claseDelDia)
            {
                if (aux == clase)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Evalúa si un profesor no da una clase.
        /// </summary>
        /// <param name="i">Profesor a evaluar</param>
        /// <param name="clase">Clase a evaluar</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}
