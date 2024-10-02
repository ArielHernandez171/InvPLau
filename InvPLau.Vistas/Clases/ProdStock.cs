﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvPLau.Vistas.Clases
{
    public class ProdStock
    {
        public float? Precio { get; set; }
        public float? Cantidad { get; set; }
        /*
         * Refiere al stock del producto
         * siendo cantidad la cantidad de unidades
         * y precio, el precio del producto al momento de consumir
         * pudiendo variar en base al tipo del producto
         * al cual pertenece el stock
         */
    }
}
