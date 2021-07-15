using CoronaMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}