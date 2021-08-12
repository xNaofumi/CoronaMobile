using CoronaMobile.Views;
using System;
using Xamarin.Forms;

namespace CoronaMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute($"{nameof(AboutPage)}/{nameof(LoginFormPage)}", typeof(LoginFormPage));
            Routing.RegisterRoute($"{nameof(AboutPage)}/{nameof(RegisterFormPage)}", typeof(RegisterFormPage));
        }

        private void OnAppExit(object sender, EventArgs e)
        {
            App.Current.Quit();
        }
    }
}
