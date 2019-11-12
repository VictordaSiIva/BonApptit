using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using BonApptit.Modelos;
using BonApptit.Banco;

namespace BonApptit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopUpConfirmar : PopupPage
	{
        
        public Pedido pedido;
        public int id;
        public Mesa mesa;
        DataBase banco = new DataBase();
        List<Pedido> lista = new List<Pedido>();
        public PopUpConfirmar (Pedido pedido, Mesa mesa, DataBase banco, List<Pedido> lista )
		{
			InitializeComponent ();
            this.lista = lista;
            this.pedido = pedido;
            this.mesa = mesa;
            this.banco = banco;
          
            

		}

        private void Confirmar(object sender, EventArgs args)
        {
            
            this.id = pedido.Id;
            lista.Add(pedido);
            banco.InserirPedido(pedido);
            mesa.pedidos = lista;
            
            App.Current.MainPage = new NavigationPage(new Views.MeusPedidos(mesa, banco, lista));

            PopupNavigation.Instance.PopAsync(true);
            
        }

        private void Manter(object sender, EventArgs args)
        {

          
            PopupNavigation.Instance.PopAsync(true);
        }




    }
}