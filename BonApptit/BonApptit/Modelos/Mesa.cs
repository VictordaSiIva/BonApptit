using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BonApptit.Modelos
{
    [Table ("Mesa")]
    public class Mesa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string nome { get; set; }

        [OneToMany]
        public List<Pedido> pedidos { get; set; }

 

    }
}
