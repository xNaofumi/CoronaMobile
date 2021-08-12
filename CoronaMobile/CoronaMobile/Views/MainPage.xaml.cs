using CoronaMobile.ViewModels;
using Xamarin.Forms;

namespace CoronaMobile.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }
    }
}