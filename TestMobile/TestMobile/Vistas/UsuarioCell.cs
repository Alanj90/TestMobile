using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestMobile.Vistas
{
    class UsuarioCell : ViewCell
    {
        public UsuarioCell()
        {
            var lblId = new Label { };

            var IdUsuario = new Label
            {
                TextColor = Color.Black,
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            IdUsuario.SetBinding(Label.TextProperty, new Binding("IdUsuario"));

            var Usuario = new Label
            {
                TextColor = Color.Black,
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center
            };

            Usuario.SetBinding(Label.TextProperty, new Binding("Usuario"));

            var Nombre = new Label
            {
                TextColor = Color.Black,
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center
            };

            Nombre.SetBinding(Label.TextProperty, new Binding("Nombre"));

            var FechaCreacion = new Label
            {
                TextColor = Color.Black,
                Font = Font.BoldSystemFontOfSize(NamedSize.Medium),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center
            };

            FechaCreacion.SetBinding(Label.TextProperty, new Binding("FechaCreacion"));

            var Activo = new Switch
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.Center,
                IsEnabled = false
            };

            Activo.SetBinding(Switch.IsToggledProperty, new Binding("Activo"));

            var rowEncabezado = new StackLayout
            {
                Children = { IdUsuario, Usuario },
                Orientation = StackOrientation.Horizontal
            };

            var rowContenido = new StackLayout
            {
                Children = { Nombre, FechaCreacion, Activo },
                Orientation = StackOrientation.Horizontal
            };

            View = new StackLayout
            {
                Children = { rowEncabezado, rowContenido },
                Orientation = StackOrientation.Vertical
            };
        }
    }
}
