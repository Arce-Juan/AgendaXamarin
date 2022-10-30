using System;
using Xamarin.Forms;

namespace AgendaContactos.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        public void LoginUser(object sender, EventArgs args)
        {
            Navigation.PushAsync(new LogueoUsuario());
        }

        public void NuevoUsuario(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NuevoUsuarioPage());
        }
    }
}