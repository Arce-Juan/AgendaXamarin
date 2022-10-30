using AgendaContactos.Infraestructure.Sqlite;
using AgendaContactos.Services;
using AgendaContactos.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaContactos
{
    public partial class App : Application
    {
        private static SQLiteContext sqliteContext;
        public static SQLiteContext SQLiteContext
        {
            get
            {
                if (sqliteContext == null)
                {
                    sqliteContext = new SQLiteContext(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "ContactosDeUsuario_6.db3"));
                }
                return sqliteContext;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
