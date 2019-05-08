using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comerciante
    {
        private string apellido;
        private string nombre;

        public Comerciante(string nombre, string apellido)
        {
            this.apellido = apellido;
            this.nombre = nombre;
        }

        public static bool operator ==(Comerciante a,Comerciante b)
        {
            if (a.nombre == b.nombre && a.apellido == b.apellido)
                return true;
            else
                return false;
        }

        public static bool operator !=(Comerciante a, Comerciante b)
        {
            return !(a == b);
        }

        public static implicit operator string(Comerciante a)
        {
            return a.nombre + " - " + a.apellido;
        }
    }
}
