using AgendaContactos.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AgendaContactos.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}