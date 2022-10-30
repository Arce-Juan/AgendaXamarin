using AgendaContactos.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaContactos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerContactoPage : ContentPage
    {
        public VerContactoPage(Contacto _contacto)
        {
            InitializeComponent();
            BindingContext = _contacto;
        }
    }
}