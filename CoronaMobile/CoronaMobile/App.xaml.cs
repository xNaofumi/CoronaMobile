using CoronaMobile.Services;
using CoronaMobile.Views;
using Xamarin.Forms;
using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace CoronaMobile
{
    public partial class App : Application
    {
        public readonly HttpClient Client;
        public readonly string ServerUrl;

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            Client = new HttpClient();
            ServerUrl = "http://194.87.92.52:8080";
            Client.BaseAddress = new Uri(ServerUrl);
            CheckServerConnection();
        }

        private async void CheckServerConnection()
        {
            try
            {
                string responseBody = await Client.GetStringAsync(ServerUrl);
            }
            catch (Exception ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Ошибка подключения к серверу", ex.Message, "OK");
                await Task.Delay(10000);
                CheckServerConnection();
            }
        }

        protected override void OnStart()
        {
            Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
