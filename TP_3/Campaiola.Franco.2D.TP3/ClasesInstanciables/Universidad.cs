using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    #region Serialización

    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Profesor))]

    #endregion

    public class Universidad
    {
        #region Atributos

        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesor;

        #endregion

        #region Propiedades L/E

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this._profesor; }
            set { this._profesor = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }

        public Jornada this[int i]
        {
            get { return this._jornada[i]; }
            set { this._jornada[i] = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una universidad.
        /// </summary>
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesor = new List<Profesor>();
        }

        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Evalúa si un alumno se encuentra en una universidad.
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="a">Alumno a evaluar</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno aux in g._alumnos)
            {
                if (aux == a)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Evalúa si un alumno no se encuentra en una universidad.
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="a">Alumno a evaluar</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Evalúa si un profesor se encuentra en una universidad.
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="i">Profesor a evaluar</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor aux in g._profesor)
            {
                if (aux == i)
                    retorno = true;
                else
                    retorno = false;
            }
            return retorno;
        }

        /// <summary>
        /// Evalúa si un profesor no se encuentra en una universidad.
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="i">Profesor a evaluar</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega una clase a una universidad.
        /// </summary>
        /// <param name="g">Universidad a la que la clase será agregada</param>
        /// <param name="clase">Clase a agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);

            foreach (Alumno aux in g._alumnos)
            {
                if (aux == clase)
                {
                    j += aux;
                }
            }

            g._jornada.Add(j);
            return g;
        }

        /// <summary>
        /// Agrega un alumno a una universidad.
        /// </summary>
        /// <param name="g">Universidad a la que el alumno será agregado</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            foreach (Alumno aux in g._alumnos)
            {
                if (aux == a)
                    throw new AlumnoRepetidoException();
            }

            g._alumnos.Add(a);
            return g;
        }

        /// <summary>
        /// Agrega un profesor a una universidad.
        /// </summary>
        /// <param name="g">Universidad a la que el profesor será agregado</param>
        /// <param name="i">Profesor a agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            foreach (Profesor aux in g._profesor)
            {
                if (aux == i)
                    return g;
            }

            g._profesor.Add(i);
            return g;
        }

        /// <summary>
        /// Evalúa si en una universidad se brinda cierta clase.
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="clase">Clase a evaluar</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor aux in g._profesor)
            {
                if (aux == clase)
                    return aux;
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Evalúa si en una universidad no se brinda cierta clase.
        /// </summary>
        /// <param name="g">Universidad a evaluar</param>
        /// <param name="clase">Clase a evaluar</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor aux in g._profesor)
            {
                if (aux != clase)
                    return aux;
            }

            throw new SinProfesorException();
        }

        #endregion

        #region Polimorfismo ToString

        /// <summary>
        /// Retorna los datos de una universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Devuelve los datos de una universidad en específica.
        /// </summary>
        /// <param name="gim">Universidad a evaluar</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendLine("JORNADA: ");
            foreach (Jornada aux in gim._jornada)
                sb.AppendLine(aux.ToString());

            sb.AppendLine("Lista total de alumnos: ");
            foreach (Alumno a in gim._alumnos)
                sb.AppendLine(a.ToString());

            sb.AppendLine("Lista total de profesores: ");
            foreach (Profesor i in gim._profesor)
                sb.AppendLine(i.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Guarda una universidad en un archivo de texto.
        /// </summary>
        /// <param name="gim">Universidad a ser guardada</param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> arc = new Xml<Universidad>();
            return arc.Guardar(@"C:\\Universidad.xml", gim);
        }

        #endregion
    }
}
