using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables 
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]

    public class Jornada
    {
        private List<Alumno> _alumnos;
        private EClases _clase;
        private Profesor _instructor;

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno aux in j._alumnos)
            {
                if (aux == a)
                    retorno = true;
                else
                    retorno = false;
            }
            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
            }
            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASE DE " + this.Clase + " POR " + this.Instructor.ToString());

            sb.AppendLine("ALUMNOS: ");
            for (int i = 0; i < this._alumnos.Count; i++)
            {
                sb.AppendLine(this.Alumnos[i].ToString());
            }

            sb.AppendLine("<-------------------------------->");

            return sb.ToString();
        }

        public static bool Guardar(Jornada j)
        {
            Texto texto = new Texto();
            return texto.Guardar(@"C:\\Jornada.txt", j.ToString());
        }

        public string Leer()
        {
            string cadena = " ";
            Texto texto = new Texto();
            texto.Leer(@"C:\\Jornada.txt", out cadena);
            return cadena;
        }
    }
}
