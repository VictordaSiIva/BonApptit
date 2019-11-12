using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BonApptit.Modelos
{
     public class LancheAdicional
    {
        [ForeignKey(typeof(Adicional))]
        public int adicionalID { get; set; }

        [ForeignKey(typeof(Lanches))]
        public int lancheID { get; set; }

    }
}
