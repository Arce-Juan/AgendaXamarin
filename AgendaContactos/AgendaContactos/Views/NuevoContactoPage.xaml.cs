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
    public partial class NuevoContactoPage : ContentPage
    {
        public NuevoContactoPage()
        {
            InitializeComponent();
        }

        public async void GuardarContactoAction(object sender, EventArgs args)
        {
            if (string.IsNullOrEmpty(Apellido.Text)
                || string.IsNullOrEmpty(Nombre.Text)
                || string.IsNullOrEmpty(Numero.Text)
                || string.IsNullOrEmpty(Direccion.Text)
                || string.IsNullOrEmpty(Email.Text)
                )
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios", "Cerrar");
                return;
            }

            var categoria = picker.SelectedItem.ToString();

            var contacto = new Contacto()
            {
                Id = App.SQLiteContext.NuevoIdContactoAsync(),
                Apellido = Apellido.Text,
                Nombre = Nombre.Text,
                Numero = Numero.Text,
                Direccion = Direccion.Text,
                Email = Email.Text,
                IdUsuario = int.Parse(App.Current.Properties["Session_IdUsuario"].ToString()),
                Categoria = categoria,
            };

            await App.SQLiteContext.GuardarContactoAsync(contacto);
            Navigation.PushAsync(new ListaContactosPage());
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new ListaContactosPage());
            return false;
        }
    }
}