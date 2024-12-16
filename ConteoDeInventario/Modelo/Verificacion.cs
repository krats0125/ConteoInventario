using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoDeInventario.Modelo
{
    public class Verificacion
    {
        public int IdVerificacion { get; set; }
        public int Idreferencia { get; set; }
        public string referencia { get; set; }
        public double InventarioMomento { get; set; }
        public double InventarioConteo { get; set; }
        public double Diferencia { get; set; }
        public DateTime FechaConteo { get; set; }
        public string Contador { get; set; }
        public int Ciclo { get; set; }

    }
}
