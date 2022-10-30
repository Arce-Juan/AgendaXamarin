using AgendaContactos.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaContactos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaContactosPage : ContentPage
    {
        public int IdUsuarioSesion { get; set; }

        public ListaContactosPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var idUsuario = int.Parse(App.Current.Properties["Session_IdUsuario"].ToString());
            var contactos = await App.SQLiteContext.ObtenerContactosDeUsuarioAsync(idUsuario);
            collectionView.ItemsSource = contactos;
        }

        public void VerContactoAction(object sender, EventArgs args)
        {
            Image lblEditar = (Image)sender;
            TapGestureRecognizer tapGes = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
            var contacto = tapGes.CommandParameter as Contacto;
            Navigation.PushAsync(new VerContactoPage(contacto));
        }

        public void NuevoContactoAction(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NuevoContactoPage());
        }

        public void EditarContactoAction(object sender, EventArgs args)
        {
            Image lblEditar = (Image)sender;
            TapGestureRecognizer tapGes = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
            var contacto = tapGes.CommandParameter as Contacto;
            Navigation.PushAsync(new EditarContactoPage(contacto));
        }
        
        public void EliminarContactoAction(object sender, EventArgs args)
        {
            Image lblEditar = (Image)sender;
            TapGestureRecognizer tapGes = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
            var contacto = tapGes.CommandParameter as Contacto;
            Navigation.PushAsync(new EliminarContactoPage(contacto));
        }
    }
}