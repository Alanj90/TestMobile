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
	public partial class Menu : MasterDetailPage
	{
        string loginUsuario = "";

        public Menu (string usuario)
		{
			InitializeComponent ();
            InitializeComponent();
            loginUsuario = usuario;
            NavigationPage.SetHasNavigationBar(this, false);
            Load_Inicial();
        }

        public void Load_Inicial()
        {
            Detail = new NavigationPage(new Inicio(loginUsuario));
            List<ItemsMenu> menu = new List<ItemsMenu>
            {
                new ItemsMenu{ ItemTitle = "Usuarios", ItemDetail="Catalogo de usuarios", ItemPage = new MainPage()}
            };
            lstMenu.ItemsSource = menu;
        }

        public class ItemsMenu
        {
            public string ItemTitle { get; set; }
            public string ItemDetail { get; set; }
            public ImageSource ItemIcon { get; set; }
            public Page ItemPage { get; set; }
        }

        private async void LstMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var item = e.SelectedItem as ItemsMenu;
                if (item != null)
                {
                    IsPresented = false;
                    await Navigation.PushAsync(item.ItemPage);
                }

                lstMenu.SelectedItem = null;
            }
        }
    }
}