﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoDeInventario.Modelo
{
    public class Producto
    {
        public int IdReferencia { get; set; }
        public string Referencia { get; set; }
        public bool Contado { get; set; }
        public string idBodega { get; set; }
    }
}
