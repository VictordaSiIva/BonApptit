using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BonApptit.Modelos
{
    public class AcompanhamentoPedido
    {

        [ForeignKey(typeof(Acompanhamento))]
        public int acompanhamentoID { get; set; }

        [ForeignKey(typeof(Pedido))]
        public int pedidoID { get; set; }
    }
}
