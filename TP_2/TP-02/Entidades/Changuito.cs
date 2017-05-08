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
        public Changuito(int espacioDisponible)
        {
            this._productos = new List<Producto>();
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concesionaria y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
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
        /// 
        public string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c._productos.Count, c._espacioDisponible);
            sb.AppendLine("");
          foreach (Producto v in c._productos)
          {
              switch (tipo)
                {
                    case ETipo.Dulce:
                        if (v is Dulce)
                            sb.AppendLine(((Dulce)v).MostrarDulce());
                        break;
                    case ETipo.Leche:
                        if (v is Leche)
                            sb.AppendLine(((Leche)v).MostrarLeche());
                        break;
                    case ETipo.Snacks:
                        if (v is Snacks)
                            sb.AppendLine(((Snacks)v).MostrarSnack());
                        break;
                    case ETipo.Todos:
                            if (v is Dulce)
                                sb.AppendLine(((Dulce)v).MostrarDulce());
                            if (v is Leche)
                                sb.AppendLine(((Leche)v).MostrarLeche());
                            if (v is Snacks)
                                sb.AppendLine(((Snacks)v).MostrarSnack());
                            break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
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
            if (c._productos.Count >= c._espacioDisponible)
                return c;

            foreach (Producto v in c._productos)
            {
                if (v == p)
                {
                    return c;
                }
            }

            c._productos.Add(p);
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            for (int i = 0; i < c._productos.Count; i++)
            {
                if (c._productos[i] == p)
                {
                    c._productos.Remove(p);
                    break;
                }
            }
            return c;
        }
        #endregion
    }
}
