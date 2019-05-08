using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comercio
    {
        protected int _cantidadDeEmpleados;
        protected Comerciante _comerciante;
        protected static Random _generadorDeEmpleados;
        protected string _nombre;
        protected float _precioAlquiler;

        public int CantidadDeEmpleados
        {
            get
            {
                this._cantidadDeEmpleados = Comercio._generadorDeEmpleados.Next(1, 100);
                return this._cantidadDeEmpleados;
            }
        }

        static Comercio()
        {
            Comercio._generadorDeEmpleados = new Random();
        }

        public Comercio(float precioAlquiler,string nombreComercio,string nombre,string apellido):this(nombreComercio,new Comerciante(nombre,apellido),precioAlquiler)
        {

        }

        public Comercio(string nombre,Comerciante comerciante,float precioAlquiler)
        {
            this._comerciante = comerciante;
            this._nombre = nombre;
            this._precioAlquiler = precioAlquiler;
        }

        private static string Mostrar(Comercio c)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE: " + c._nombre);
            sb.AppendLine("CANTIDAD DE EMPLEADOS: " + c.CantidadDeEmpleados);
            sb.AppendLine("COMERCIANTE: " + c._comerciante);
            sb.AppendLine("PRECIO ALQUILER: " + c._precioAlquiler.ToString());

            return sb.ToString();
        }

        public static bool operator ==(Comercio a, Comercio b)
        {
            if (a._nombre == b._nombre && a._comerciante == b._comerciante)
                return true;
            else
                return false;
        }

        public static bool operator !=(Comercio a, Comercio b)
        {
            return !(a == b);
        }

        public static explicit operator string(Comercio c)
        {
            return Comercio.Mostrar(c);
        }
    }
}
