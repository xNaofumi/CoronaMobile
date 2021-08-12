using CoronaMobile.Models;
using CoronaMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CoronaMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        private Hospital _hospital;

        public ItemDetailPage(Hospital item)
        {
            InitializeComponent();
            new ItemDetailViewModel();

            _hospital = item;
            BindingContext = _hospital;
        }
    }
}