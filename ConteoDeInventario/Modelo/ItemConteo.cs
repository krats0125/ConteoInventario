using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoDeInventario.Modelo
{
    public class ItemConteo
    {
        public string IdTrabajador { get; set; }
        public string Trabajador { get; set; }
        public int Rol { get; set; }
        public string codigo { get; set; }  
        public bool Bodegainterna { get; set; }
        public List<Producto> Productos { get; set; }   
    }
}
