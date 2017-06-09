using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario: Persona
    {
        private int _legajo;

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append("Legajo: " + this._legajo);
            sb.AppendLine("");
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public Universitario(): base() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1._legajo == pg2._legajo || pg1.Dni == pg2.Dni)
                return true;
            else
                return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

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
    }
}
