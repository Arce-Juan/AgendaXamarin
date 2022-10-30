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
    public partial class EliminarContactoPage : ContentPage
    {
        public EliminarContactoPage(Contacto _contacto)
        {
            InitializeComponent();
            BindingContext = _contacto;
        }

        public async void EliminarContactoAction(object sender, EventArgs args)
        {
            var contacto = await App.SQLiteContext.ObtenerContactosPorIdAsync(int.Parse(IdContacto.Text));

            await App.SQLiteContext.EliminarContactoAsync(contacto);

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