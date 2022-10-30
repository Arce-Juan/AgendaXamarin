using AgendaContactos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaContactos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogueoUsuario : ContentPage
    {
        public LogueoUsuario()
        {
            InitializeComponent();
        }

        public void LoginUser(object sender, EventArgs args)
        {
            var usuario = App.SQLiteContext.ObtenerUsuarioPorNombreContrasenaAsync(Nombre.Text, Contrasena.Text).Result;

            if (usuario != null)
            {
                App.Current.Properties["Session_IdUsuario"] = usuario.Id;
                Navigation.PushAsync(new ListaContactosPage()
                {
                    IdUsuarioSesion = usuario.Id
                });

            }
            else
                DisplayAlert("Error", "El usuario y/o contraseña no son validos", "Cerrar");
        }
    }
}