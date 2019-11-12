using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
namespace BonApptit.Modelos
{
    [Table("Pedido")]
    public class Pedido : INotifyPropertyChanged
    {
        private double _totalPedido;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string descricao { get; set; }
        public string pagamento { get; set; }
        public Button button;
        public double totalPedido { get { return _totalPedido; } set { _totalPedido = value; Mudar(); } }

        [ForeignKey(typeof(Mesa))]
        public int MesaID { get; set; }

        [ManyToMany(typeof(LanchesPedido))]
        public List<Lanches> lanches { get; set; }

        [ManyToMany(typeof(AcompanhamentoPedido))]
        public List<Acompanhamento> acompanhamentos { get; set; }

        [ManyToMany(typeof(SobremesaPedido))]
        public List<Sobremesa> sobremesas { get; set; }

        [ManyToMany(typeof(BebidaPedido))]
        public List<Bebida> bebidas { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Mudar([CallerMemberName]string mudar = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(mudar));

        }
    }

}


