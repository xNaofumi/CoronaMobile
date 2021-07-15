using CoronaMobile.ViewModels;
using CoronaMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CoronaMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute($"{nameof(LoginPage)}/{nameof(LoginFormPage)}", typeof(LoginFormPage));
            Routing.RegisterRoute($"{nameof(LoginPage)}/{nameof(RegisterFormPage)}", typeof(RegisterFormPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
