using CoronaMobile.ViewModels;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoronaMobile.Views
{
    public partial class LoginPage : ContentPage
    {
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}