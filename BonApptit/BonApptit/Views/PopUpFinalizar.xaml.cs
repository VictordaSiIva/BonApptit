using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace BonApptit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopUpFinalizar : PopupPage
	{
		public PopUpFinalizar ()
		{
			InitializeComponent ();

            mensagem.Text = "Agradecemos pela preferência e volte sempre!" + Environment.NewLine + "Dirija-se ao Caixa e informe o seu nome e a mesa de atendimento!";
            mensagem.FontFamily = Device.OnPlatform("Sansation", "Sansation_Bold_Italic.ttf#Phenomena Black", "Assets/Sansation_Bold_Italic.ttf#Sansation");
            
            
        }

        private void OK(object sender, EventArgs args)
        {
            
            PopupNavigation.Instance.PopAsync(true);
            App.Current.MainPage = new BonApptit.Views.TelaInicial();
        }
    }
}