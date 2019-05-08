using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Importador : Comercio
    {
        public EPaises paisOrigen;

        public Importador(string nombreComercio,float precioAlquiler,Comerciante comerciante,EPaises paisOrigen):base(nombreComercio,comerciante,precioAlquiler)
        {
            this.paisOrigen = paisOrigen;
        }

        public string Mostrar()
        {
            return (string)this + "Tipo: " + this.paisOrigen.ToString() + "\n";
        }

        public static bool operator ==(Importador a, Importador b)
        {
            if (a.paisOrigen == b.paisOrigen && (Comercio)a == (Comercio)b)
                return true;
            else
                return false;
        }

        public static bool operator !=(Importador a, Importador b)
        {
            return !(a == b);
        }

        public static implicit operator double(Importador n)
        {
            return n._precioAlquiler;
        }
    }
}
