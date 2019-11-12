using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace BonApptit.Modelos
{
    public class BebidaPedido
    {

        [ForeignKey(typeof(Bebida))]
        public int bebidaID { get; set; }

        [ForeignKey(typeof(Pedido))]
        public int pedidoID { get; set; }



    }
}
