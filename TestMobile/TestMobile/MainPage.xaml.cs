using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestMobile.Entidades;
using TestMobile.Vistas;

namespace TestMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        List<Perfiles> perfiles;

        public MainPage()
        {
            InitializeComponent();
            Load_Inicial();
        }

        void Load_Inicial()
        {
            lstListado.ItemTemplate = new DataTemplate(typeof(UsuarioCell));
            lstListado.RowHeight = 55;

            //Cargamos los perfiles manualmente
            perfiles = new List<Perfiles>();
            perfiles.Add(new Perfiles { IdPerfil = 1, Perfil = "Administrador" });
            perfiles.Add(new Perfiles { IdPerfil = 2, Perfil = "Editor" });
            perfiles.Add(new Perfiles { IdPerfil = 3, Perfil = "Consultor" });

            foreach (var p in perfiles)
            {
                pkPerfil.Items.Add(p.Perfil);
            }

            pkPerfil.SelectedIndex = 0;
            lblIdPerfil.Text = "1";
        }

        private void PkPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            int position = pkPerfil.SelectedIndex;

            if (position > -1)
            {
                if (position == 0)
                    lblIdPerfil.Text = "1";
                else if (position == 1)
                    lblIdPerfil.Text = "2";
                else if (position == 2)
                    lblIdPerfil.Text = "3";
                else
                    lblIdPerfil.Text = "0";
            }
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            string mensaje = "";
            if (!Validar(out mensaje))
            {
                await DisplayAlert("Error", mensaje, "Aceptar");
                entUsuario.Focus();
                return;
            }

            Usuarios usuario = new Usuarios
            {
                Usuario = entUsuario.Text,
                Password = entPassword.Text,
                Nombre = entNombre.Text,
                IdPerfil = int.Parse(lblIdPerfil.Text),
                FechaCreacion = DateTime.Now,
                Activo = swtActivo.IsToggled
            };

            using (var datos = new DataAccess())
            {
                datos.Insert_Usuario(usuario);
                lstListado.ItemsSource = datos.Report_Usuario();
                Limpiar_Formulario();
            }
        }

        public bool Validar(out string mensaje)
        {
            bool result = false;
            mensaje = "";

            if (String.IsNullOrEmpty(entUsuario.Text))
                mensaje += "Ingrese Usuario \n";

            if (String.IsNullOrEmpty(entPassword.Text))
                mensaje += "Ingrese Password \n";

            if (String.IsNullOrEmpty(entNombre.Text))
                mensaje += "Ingrese Nombre \n";

            if (String.IsNullOrEmpty(lblIdPerfil.Text))
                mensaje += "Seleccione un Perfil \n";
            else
            {
                int idPerfil = 0;
                if (!int.TryParse(lblIdPerfil.Text.Trim(), out idPerfil))
                    mensaje += "Seleccione un Perfil \n";
            }

            if (String.IsNullOrEmpty(mensaje))
                result = true;

            return result;
        }

        void Limpiar_Formulario()
        {
            entUsuario.Text = String.Empty;
            entPassword.Text = String.Empty;
            entNombre.Text = String.Empty;
            pkPerfil.SelectedIndex = 0;
            lblIdPerfil.Text = "1";
        }

        private void LstListado_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var usuario = (Usuarios)e.SelectedItem;
                lstListado.SelectedItem = null;
                Navigation.PushAsync(new EditPage(usuario));
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var datos = new DataAccess())
            {
                lstListado.ItemsSource = datos.Report_Usuario();
            }
        }
    }
}