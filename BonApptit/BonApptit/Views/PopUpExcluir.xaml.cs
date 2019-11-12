using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using BonApptit.Modelos;
using Xamarin.Forms.Xaml;
using BonApptit.Banco;

namespace BonApptit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopUpExcluir : PopupPage
	{
        public Mesa mesa;
        DataBase banco = new DataBase();
        List<Pedido> lista = new List<Pedido>();
        Pedido pe = new Pedido();
        ListView listaPedidos = new ListView();
		public PopUpExcluir(List<Pedido> lista, Pedido pe, ListView listapedidos, Mesa mesa, DataBase banco)
		{
         

			InitializeComponent ();
            

            this.lista = lista;
            this.pe = pe;
            this.mesa = mesa;
            this.banco = banco;
            this.listaPedidos = listapedidos;
            
           
           

            
        }

        private void Confirmar(object sender, EventArgs args)
        {
            lista.Remove(pe);
            listaPedidos.ItemsSource = lista;
            App.Current.MainPage = new NavigationPage(new Views.MeusPedidos(mesa, banco, lista));
            PopupNavigation.Instance.PopAsync(true);
            
        }

        private void Manter(object sender, EventArgs args)
        {
            
            PopupNavigation.Instance.PopAsync(true);
            
        }
        

    }
}