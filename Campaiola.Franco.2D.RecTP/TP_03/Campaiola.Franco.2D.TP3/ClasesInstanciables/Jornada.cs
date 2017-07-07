﻿using System;
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
        #region Atributos
        private List<Alumno> _alumnos;
        private EClases _clase;
        private Profesor _instructor;
        #endregion

        #region Constructores
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
        #endregion

        #region Propiedades
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
        #endregion

        #region Sobrecarga de Operadores
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
        #endregion

        #region Polimorfismo
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
        #endregion

        #region Métodos
        /// <summary>
        /// Guarda una jornada recibiendola como parámetro en un archivo de texto.
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada j)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", j.ToString());
        }

        /// <summary>
        /// Lee una jornada.
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            string cadena = " ";
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out cadena);
            return cadena;
        }
        #endregion
    }
}
