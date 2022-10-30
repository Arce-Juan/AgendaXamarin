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
    public partial class NuevoUsuarioPage : ContentPage
    {
        public NuevoUsuarioPage()
        {
            InitializeComponent();
        }

        public async void GuardarAction(object sender, EventArgs args)
        {
            if (string.IsNullOrEmpty(Nombre.Text) || string.IsNullOrEmpty(Contrasena.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios", "Cerrar");
                return;
            }

            if (App.SQLiteContext.ExisteNombreUsuarioAsync(Nombre.Text))
                await DisplayAlert("Error", "Ya existe ese nombre de usuario", "Cerrar");
            else
            {
                var usuario = new Usuario()
                {
                    Nombre = Nombre.Text,
                    Contrasena = Contrasena.Text,
                    Activo = 1
                };
                await App.SQLiteContext.GuardarUsuarioAsync(usuario);
                Navigation.PushAsync(new AboutPage());
            }

        }
    }
}