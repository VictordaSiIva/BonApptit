using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BonApptit.Modelos
{
    [Table ("Acompanhamento")]
    public class Acompanhamento : INotifyPropertyChanged
    {

        private double _precoTotal;
        private int _quantidade;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public double precoTotal { get { return _precoTotal; } set { _precoTotal = value; Mudar(); } }
        public int quantidade { get { return _quantidade; } set { _quantidade = value; Mudar(); } }

        [ManyToMany(typeof(AcompanhamentoPedido))]
        public List<Pedido> pedidos { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;



        private void Mudar([CallerMemberName]string mudar = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(mudar));

        }
    }
}
