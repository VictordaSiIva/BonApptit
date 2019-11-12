using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BonApptit.Modelos;
using BonApptit.Banco;

namespace BonApptit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MeusPedidos : ContentPage
	{
        Point point = new Point();
        
        public Mesa mesa;
        DataBase banco = new DataBase();
        List<Pedido> pedido = new List<Pedido>();
        
		public MeusPedidos (Mesa mesa, DataBase banco, List<Pedido> lista)
		{
			InitializeComponent ();
            switch(Device.RuntimePlatform)
            {
               
                case Device.UWP:
                    {

                        listaPedidos.Margin = new Thickness(130, 30, 0, 0);
                        tst.Margin = new Thickness(-30, 0, 0, 0);

                        break;
                    }

            }
            this.pedido = lista;
            this.banco = banco;
            this.mesa = mesa;

            listaPedidos.ItemsSource = mesa.pedidos;
		}

        private void NovoPedido(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new Views.TelaPedido(mesa, banco, pedido));

        }


        private void Excluir(object sender, EventArgs args)
        {

            var button = sender as Button;
            
            var lista = (List<Pedido>)listaPedidos.ItemsSource;

            var pe = button.BindingContext as Pedido;



            PopupNavigation.Instance.PushAsync(new PopUpExcluir(lista, pe, listaPedidos, mesa, banco));

        }


        private void Finalizar(object sender, EventArgs args)
        {
            var lista = (List<Pedido>)listaPedidos.ItemsSource;
            if (lista.Count != 0)
            {

                PopupNavigation.Instance.PushAsync(new PopUpFinalizar());
            }
            else
            {

                menssagem.Text = "faça um pedido antes de finalizar!";
                menssagem.TextColor = Color.Red;
                menssagem.FontAttributes = FontAttributes.Bold;
            }
        }




    }
}