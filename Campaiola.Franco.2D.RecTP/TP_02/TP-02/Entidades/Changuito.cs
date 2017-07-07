using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Changuito
    {
        List<Producto> _productos;
        int _espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this._productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible): this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c._productos.Count, c._espacioDisponible);
            sb.AppendLine("");
            sb.AppendLine(c.MostrarProductos(tipo));
            return sb.ToString();
        }

        public string MostrarProductos(ETipo tipo) //quitar static
        {
            StringBuilder sb = new StringBuilder();

            if (tipo == ETipo.Snacks)
            {
                foreach (Producto v in this._productos)
                {
                    if (v is Snacks)
                    {
                        sb.AppendLine(((Snacks)v).Mostrar());
                    }
                }
            }

            if (tipo == ETipo.Dulce)
            {
                foreach (Producto v in this._productos)
                {
                    if (v is Dulce)
                    {
                        sb.AppendLine(((Dulce)v).Mostrar());
                    }
                }
            }

            if (tipo == ETipo.Leche)
            {
                foreach (Producto v in this._productos)
                {
                    if (v is Leche)
                    {
                        sb.AppendLine(((Leche)v).Mostrar());
                    }
                }
            }

            if (tipo == ETipo.Todos)
            {
                foreach (Producto v in this._productos)
                {
                    if (v is Snacks)
                    {
                        sb.AppendLine(((Snacks)v).Mostrar());
                    }

                    else if (v is Dulce)
                    {
                        sb.AppendLine(((Dulce)v).Mostrar());
                    }

                    else if (v is Leche)
                    {
                        sb.AppendLine(((Leche)v).Mostrar());
                    }
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            bool retorno = false;
            Changuito cc = c;

            if (c._espacioDisponible > c._productos.Count)
            {
                foreach (Producto v in cc._productos)
                {
                    if (v == p)
                    {
                        retorno = true;
                    }
                }

                if (!retorno)
                {
                    cc._productos.Add(p);
                }
            }

            return cc;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            bool retorno = false;
            Changuito cc = c;

            foreach (Producto v in cc._productos)
            {
                if (v == p)
                {
                    retorno = true;
                }
            }

            if (retorno)
            {
                cc._productos.Remove(p);
            }

            return cc;
        }
        #endregion
    }
}
