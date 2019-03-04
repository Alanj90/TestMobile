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
	public partial class Inicio : ContentPage
	{
		public Inicio (string usuario)
		{
			InitializeComponent ();

            if (string.IsNullOrEmpty(usuario))
                lblUsuario.Text = string.Empty;
            else
                lblUsuario.Text = usuario;
        }
	}
}