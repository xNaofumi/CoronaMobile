using CoronaMobile.ViewModels;
using Xamarin.Forms;

namespace CoronaMobile.Views
{
    public partial class RegisterFormPage : ContentPage
    {
        public RegisterFormPage()
        {
            InitializeComponent();

            BindingContext = new RegisterFormViewModel(); 
        }
    }
}