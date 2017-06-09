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
        private Queue<EClases> _claseDelDia;
        private static Random _random;

        private void _randomClases()
        {
            this._claseDelDia.Enqueue((EClases)_random.Next(0, 4));
            this._claseDelDia.Enqueue((EClases)_random.Next(0, 4));
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

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

        public override string ToString()
        {
            return this.MostrarDatos();
        }

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
        
    }
}
