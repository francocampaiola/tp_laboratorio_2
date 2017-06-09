using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = ValidarNombreApellido(value); }
        }

        public int Dni
        {
            get { return this._dni; }
            set { this._dni = ValidarDni(this._nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = ValidarNombreApellido(value); }
        }

        public string StringToDni
        {
            set
            {
                try
                {
                    this._dni = ValidarDni(this._nacionalidad, value);
                }

                catch (Exception)
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._nacionalidad = nacionalidad;
            this._apellido = apellido;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad): this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre completo: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("Nacionalidad: " + this.Nacionalidad.ToString());
            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino && dato > 0 && dato < 90000000) || (nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999))
                return dato;
            throw new DniInvalidoException();
        }

       private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));
        }

        private string ValidarNombreApellido(string dato)
        {
            Regex rg = new Regex(@"^[a-zA-Z]$");
            if (rg.IsMatch(dato))
                return dato;
            else
                return null;
        }
    }
}
