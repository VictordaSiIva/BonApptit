using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BonApptit.Modelos
{
    class SobremesaPedido
    {

        [ForeignKey(typeof(Sobremesa))]
        public int sobremesaID { get; set; }

        [ForeignKey(typeof(Pedido))]
        public int pedidoID { get; set; }
    }
}

