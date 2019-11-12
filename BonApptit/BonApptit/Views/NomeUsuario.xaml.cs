using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BonApptit.Modelos;
using BonApptit.Banco;
using System.Text.RegularExpressions;
using BonApptit.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BonApptit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NomeUsuario : ContentPage
	{
        List<Pedido> lista = new List<Pedido>();
        DataBase banco = new DataBase();
        Mesa mesa = new Mesa();

        public NomeUsuario ()
		{

            InitializeComponent ();

            bg.BackgroundImageSource = "background.png";


        }


       
        

        public void GoPaginaPedido(object sender, EventArgs args)
        {
           
           
           mesa.nome  = nomeUsuario.Text;
            if (mesa.nome == null || mesa.nome.Trim().Equals(""))

            {
                erros.Text = "O campo não pode ser vazio!";
               // DisplayAlert("Mensagem de Erro", "O campo não pode ser vazio!", "Ok");
                nomeUsuario.Focus();
            }
            else if (!Regex.IsMatch(mesa.nome, @"^[ a-zA-Z á]*$"))
            {
                erros.Text = "O campo não pode conter números ou caracteres especiais!";
                //  DisplayAlert("Mensagem de Erro", "O campo não pode conter números ou caracteres especiais!", "Ok");
                nomeUsuario.Focus();

            }

            else if (mesa.nome.Length >= 20)
            {
                erros.Text = "É permitido até 20 caracteres!";
                // DisplayAlert("Mensagem de Erro", "É permitido até 20 caracteres!", "Ok");
                nomeUsuario.Focus();

            }

            else if (mesa.nome.Length < 3)
            {
                erros.Text = "Digite pelo menos 3 caracteres!";
        
                nomeUsuario.Focus();

            }

            else
            {
                App.Current.MainPage = new NavigationPage(new Views.TelaPedido(mesa, banco, lista));

            }

        }
    }
}