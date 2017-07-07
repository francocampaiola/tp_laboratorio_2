using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    [Serializable]

    public sealed class Profesor: Universitario
    {
        #region Atributos
        private Queue<EClases> _claseDelDia;
        private static Random _random;
        #endregion

        #region Constructores
        static Profesor()
        {
           _random = new Random();
        }

        public Profesor()
        { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseDelDia = new Queue<EClases>();
            this._randomClases();
        }    
        #endregion

        #region Métodos
        /// <summary>
        /// Elije dos clases para cada Profesor.
        /// </summary>
        private void _randomClases()
        {
            this._claseDelDia.Enqueue((EClases)_random.Next(0, 4));
            this._claseDelDia.Enqueue((EClases)_random.Next(0, 4));
        }

        /// <summary>
        /// Muestra datos del Profesor.
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
        /// Hace "participar en clase" a un Profesor.
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

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
