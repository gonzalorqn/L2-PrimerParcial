using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Shopping
    {
        private int _capacidad;
        private List<Comercio> _comercios;

        private Shopping()
        {
            this._comercios = new List<Comercio>();
        }

        private Shopping(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        private double ObtenerPrecio(EComercio tipoComercio)
        {
            double retorno = 0;
            switch (tipoComercio)
            {
                case EComercio.Importador:
                    foreach (Comercio item in this._comercios)
                    {
                        if(item is Importador)
                            retorno += (Importador)item;
                    }
                    break;
                case EComercio.Exportador:
                    foreach (Comercio item in this._comercios)
                    {
                        if (item is Exportador)
                            retorno += (Exportador)item;
                    }
                    break;
                case EComercio.Ambos:
                    retorno += this.ObtenerPrecio(EComercio.Exportador);
                    retorno += this.ObtenerPrecio(EComercio.Importador);
                    break;
                default:
                    break;
            }
            return retorno;
        }

        public double PrecioDeExportadores
        {
            get { return this.ObtenerPrecio(EComercio.Exportador); }
        }

        public double PrecioDeImportadores
        {
            get { return this.ObtenerPrecio(EComercio.Importador); }
        }

        public double PrecioTotal
        {
            get { return this.ObtenerPrecio(EComercio.Ambos); }
        }

        public static string Mostrar(Shopping s)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Capacidad del Shopping: " + s._capacidad);
            sb.AppendLine("Total por Importadores: " + s.PrecioDeImportadores);
            sb.AppendLine("Total por Exportadores: " + s.PrecioDeExportadores);
            sb.AppendLine("Total: " + s.PrecioTotal);
            sb.AppendLine("***************************************");
            sb.AppendLine("Listado de Comercios");
            sb.AppendLine("***************************************");

            foreach (Comercio item in s._comercios)
            {
                if (item is Importador)
                {
                    sb.AppendLine(((Importador)item).Mostrar());
                }
                else if (item is Exportador)
                {
                    sb.AppendLine(((Exportador)item).Mostrar());
                }
            }

            return sb.ToString();
        }

        public static implicit operator Shopping(int capacidad)
        {
            Shopping s = new Shopping(capacidad);
            return s;
        }

        public static bool operator ==(Shopping s,Comercio c)
        {
            bool retorno = false;
            foreach (Comercio item in s._comercios)
            {
                if (item == c)
                    retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Shopping s, Comercio c)
        {
            return !(s == c);
        }

        public static Shopping operator +(Shopping s,Comercio c)
        {
            if(s._capacidad > s._comercios.Count)
            {
                if(s != c)
                {
                    s._comercios.Add(c);
                }
                else
                {
                    Console.WriteLine("El comercio ya está en el Shopping!!!");
                }
            }
            else
            {
                Console.WriteLine("No hay más lugar en el Shopping!!!");
            }

            return s;
        }
    }
}
