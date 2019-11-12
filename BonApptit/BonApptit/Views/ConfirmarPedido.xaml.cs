using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BonApptit.Modelos;
using BonApptit.Banco;
using Rg.Plugins.Popup.Services;
namespace BonApptit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmarPedido : ContentPage
    {
        Picker sel;
        Pedido pedido = new Pedido();
        Mesa mesa = new Mesa();
        DataBase banco = new DataBase();
        List<Pedido> lista = new List<Pedido>();
        List<Lanches> lanches = new List<Lanches>();
        List<Adicional> Adicionais = new List<Adicional>();
        List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
        List<Bebida> bebidas = new List<Bebida>();
         List<Sobremesa> sobremesas = new List<Sobremesa>();

        public ConfirmarPedido(Pedido pedido, Mesa mesa, DataBase banco, List<Pedido> lista)
        {
            InitializeComponent();
            this.lista = lista;
            this.banco = banco;
            this.pedido = pedido;
            this.mesa = mesa;
            lanches = this.pedido.lanches;
            acompanhamentos = this.pedido.acompanhamentos;
            bebidas = this.pedido.bebidas;
            sobremesas = this.pedido.sobremesas;
            ListaLanches.IsVisible = false;
            ListaAdicional.IsVisible = false;
            ListaPorcoes.IsVisible = false;
            ListaBebidas.IsVisible = false;
            ListaSobremesas.IsVisible = false;
            
            

            if (lanches.Count > 0)
            {
                
              
                
                    foreach (var item in lanches)
                    {
                    if (item.adicional != null)
                    {

                        Adicionais.AddRange(item.adicional.FindAll(f => f != null));
                    }
                    }
                
                ListaLanches.IsVisible = true;
                if (Adicionais.Count > 0)
                {
                    ListaAdicional.IsVisible = true;
                }
            }
            

            ListaLanches.ItemsSource = lanches;

            
            ListaAdicional.ItemsSource = Adicionais;
            if (acompanhamentos.Count > 0)
            {
                ListaPorcoes.IsVisible = true;
            }
            ListaPorcoes.ItemsSource = acompanhamentos;
            if (bebidas.Count > 0)
            {
                ListaBebidas.IsVisible = true;
            }
            ListaBebidas.ItemsSource = bebidas;
            if (sobremesas.Count > 0)
            {
                ListaSobremesas.IsVisible = true;
            }
            ListaSobremesas.ItemsSource = sobremesas;

            Total.Text = "R$ "+ pedido.totalPedido.ToString("0.00");
            
            
        }
        private void MudarFormaPagamento(object sender, EventArgs args)
        {
            
            Picker obj = (Picker)sender;
            sel = obj;
            if (sel.SelectedItem.ToString() == "Dinheiro")
            {
                pedido.pagamento = "Dinheiro";
            }
            else if (sel.SelectedItem.ToString() == "Cartão Débito")
            {
                pedido.pagamento = "Cartão Débito";
            }
            else 
            {
                pedido.pagamento = "Cartão Crédito";
            }
           
           


        }

        private void Confirmar(object sender, EventArgs args)
        {
            if (sel == null)
            {
                mensagem.Text = "Selecione uma forma de pagamento antes de confirmar";
            }
            else
            {
                PopupNavigation.Instance.PushAsync(new PopUpConfirmar(pedido, this.mesa, banco, lista));
            }
        }

    }
}