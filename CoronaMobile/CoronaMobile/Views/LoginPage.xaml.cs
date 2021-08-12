using CoronaMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.BindingContext = new LoginViewModel();
        }

        public void DisplayTest()
        {
            DisplayAlert("Подтвердите вход", "Войти?", "Да", "Нет");
        }
    }
}