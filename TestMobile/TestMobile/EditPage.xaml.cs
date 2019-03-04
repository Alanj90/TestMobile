using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestMobile.Entidades;

namespace TestMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage : ContentPage
	{
        private Usuarios usuario;

        public EditPage(Usuarios usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            ObtenerDatos();
        }

        void ObtenerDatos()
        {
            entUsuario.Text = usuario.Usuario;
            entPassword.Text = usuario.Password;
            entNombre.Text = usuario.Nombre;
            swtActivo.IsToggled = usuario.Activo;
        }

        private async void BtnActualizar_Clicked(object sender, EventArgs e)
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
                IdUsuario = this.usuario.IdUsuario,
                Usuario = entUsuario.Text,
                Password = entPassword.Text,
                Nombre = entNombre.Text,
                IdPerfil = this.usuario.IdPerfil,
                FechaCreacion = this.usuario.FechaCreacion,
                Activo = swtActivo.IsToggled
            };

            using (var datos = new DataAccess())
            {
                datos.Update_Usuario(usuario);
            }

            await DisplayAlert("Confirmación", "El usuario ha sido actualizado", "Aceptar");
            await Navigation.PopAsync();
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

            if (String.IsNullOrEmpty(mensaje))
                result = true;

            return result;
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var confirm = await DisplayAlert("Confirmación", "Esta seguro de eliminar al usuario " + entUsuario.Text, "Si", "No");
            if (!confirm)
                return;

            using (var datos = new DataAccess())
            {
                datos.Delete_Usuario(usuario);
            }

            await DisplayAlert("Confirmación", "El usuario ha sido eliminado", "Aceptar");
            await Navigation.PopAsync();
        }
    }
}