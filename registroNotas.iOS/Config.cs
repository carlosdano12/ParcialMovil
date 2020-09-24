using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite.Net.Interop;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(registroNotas.iOS.Config))]

namespace registroNotas.iOS
{
    class Config : Iconfig
    {
        private string directorioDB;
        private ISQLitePlatform plataforma;
        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(directorioDB))
                {
                    var directorio = Environment.GetFolderPath(
                        Environment.SpecialFolder.Personal);
                    directorioDB = Path.Combine(directorio, "..", "Library");
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