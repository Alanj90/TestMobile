using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using SQLite.Net.Interop;
using Xamarin.Forms;

//Este assembly nos permite utilizar esta clase desde el proyecto compartido
[assembly: Dependency(typeof(TestMobile.iOS.Config))]

namespace TestMobile.iOS
{
    class Config : IConfig
    {
        private string directorioDB;
        private ISQLitePlatform plataforma;

        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(directorioDB))
                {
                    var directorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    directorioDB = System.IO.Path.Combine(directorio, "..", "Library");
                }
                return directorioDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return plataforma;
            }
        }
    }
}