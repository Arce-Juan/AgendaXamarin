using AgendaContactos.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaContactos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarContactoPage : ContentPage
    {
        public EditarContactoPage(Contacto contacto)
        {
            InitializeComponent();
            BindingContext = contacto;
        }

        public async void EditarContactoAction(object sender, EventArgs args)
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

            var contacto = await App.SQLiteContext.ObtenerContactosPorIdAsync(int.Parse(IdContacto.Text));
            contacto.Apellido = Apellido.Text;
            contacto.Nombre = Nombre.Text;
            contacto.Numero = Numero.Text;
            contacto.Direccion = Direccion.Text;
            contacto.Email = Email.Text;
            contacto.Categoria = categoria;

            await App.SQLiteContext.ModificarContactoAsync(contacto);

            Navigation.PushAsync(new ListaContactosPage()
            {
                IdUsuarioSesion = 0
            });
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new ListaContactosPage());
            return false;
        }
    }
}