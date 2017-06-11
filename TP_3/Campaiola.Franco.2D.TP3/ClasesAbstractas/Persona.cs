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
        #region Atributos

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #endregion

        #region Propiedades L/E

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

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una persona.
        /// </summary>
        public Persona()
        { }

        /// <summary>
        /// Inicializa una persona con parámetros.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._nacionalidad = nacionalidad;
            this._apellido = apellido;
        }
        
        /// <summary>
        /// Inicializa una persona con más parametros. Reutilización de código.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }

        /// <summary>
        /// Inicializa una persona con más parametros. Reutilización de código.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad): this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        #endregion

        #region Polimorfismo

        /// <summary>
        /// Polimorfismo ToString.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre completo: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("Nacionalidad: " + this.Nacionalidad.ToString());
            return sb.ToString();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Valida el DNI de una persona, recibiendo un int y devolviendo un int.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino && dato > 0 && dato < 90000000) || (nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999))
                return dato;
            throw new DniInvalidoException();
        }

        /// <summary>
        /// Valida un DNI, recibiendo un string y devolviendo un int.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona (formato string)</param>
        /// <returns></returns>
       private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));
        }

        /// <summary>
        /// Valida que el nombre o apellido sea válido. Recibe un string.
        /// </summary>
        /// <param name="dato">Nombre o apellido a recibir (formato string)</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex rg = new Regex(@"^[a-zA-Z]$");
            if (rg.IsMatch(dato))
                return dato;
            else
                return null;
        }

        #endregion
    }
}
