using CoronaMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CoronaMobile.Views
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