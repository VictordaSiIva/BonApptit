using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BonApptit.Modelos
{
    public class LanchesPedido
    {
        [ForeignKey(typeof(Pedido))]
        public int pedidoID { get; set; }

        [ForeignKey(typeof(Lanches))]
        public int lancheID { get; set; }
    }
}
