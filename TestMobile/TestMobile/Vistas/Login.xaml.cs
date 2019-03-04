using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestMobile.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "";

                if (!ValidaUsuario(out mensaje))
                {
                    await DisplayAlert("Error", mensaje, "Aceptar");
                }
                else
                {
                    await Navigation.PushAsync(new Menu(entUsuario.Text));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        public bool ValidaUsuario(out string mensaje)
        {
            bool result = false;
            mensaje = "";

            string usuario = entUsuario.Text.Trim();
            string password = entPassword.Text.Trim();

            if (String.IsNullOrEmpty(usuario))
                mensaje += "Ingrese un Usuario \n";

            if (String.IsNullOrEmpty(password))
                mensaje += "Ingrese su password \n";

            if (String.IsNullOrEmpty(mensaje))
                result = true;

            return result;
        }
    }
}