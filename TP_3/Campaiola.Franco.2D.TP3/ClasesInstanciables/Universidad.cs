﻿using System;
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
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Profesor))]

    public class Universidad
    {
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesor;

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

        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesor = new List<Profesor>();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno aux in g._alumnos)
            {
                if (aux == a)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor aux in g._profesor)
            {
                if (aux == clase)
                    return aux;
            }

            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor aux in g._profesor)
            {
                if (aux != clase)
                    return aux;
            }

            throw new SinProfesorException();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

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

        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> arc = new Xml<Universidad>();
            return arc.Guardar(@"C:\\Universidad.xml", gim);
        }
    }
}
