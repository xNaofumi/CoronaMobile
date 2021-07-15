using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoronaMobile.ViewModels;

namespace CoronaMobile.Views
{
    public partial class LoginFormPage : ContentPage
    {
        public LoginFormPage()
        {
            InitializeComponent();

            this.BindingContext = new LoginFormViewModel();
        }
    }
}