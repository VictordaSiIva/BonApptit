using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BonApptit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TelaInicial : ContentPage
	{
		public TelaInicial ()
		{
			InitializeComponent ();
            bg.BackgroundImageSource ="background.png";
            
        }

        private void GoNomeUsuario(object sender, EventArgs args)
        {
            App.Current.MainPage = new BonApptit.Views.NomeUsuario();
        }

    }
}