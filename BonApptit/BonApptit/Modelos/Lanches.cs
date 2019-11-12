using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace BonApptit.Modelos
{
    [Table("Lanches")]
    public class Lanches : INotifyPropertyChanged
    {
     



        private double _precototal;
        private int _quantidade;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public double precoTotal { get { return _precototal; } set { _precototal = value; Mudar(); } }
        public string descricao { get; set; }
        public int quantidade { get { return _quantidade; } set { _quantidade = value; Mudar(); } }


        [ManyToMany(typeof(LancheAdicional))]
        public List<Adicional> adicional { get; set; }


        [ManyToMany(typeof(LanchesPedido))]
        public List<Pedido> pedidos { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Mudar([CallerMemberName]string mudar = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(mudar));

        }

   

    }
}
