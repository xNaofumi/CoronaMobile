using System;
using System.Net.Http;
using Xamarin.Forms;

namespace CoronaMobile
{
    public partial class App : Application
    {
        public static readonly HttpClient WebClient = new HttpClient();
        public readonly string ServerUrl;

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            if (WebClient.BaseAddress == null)
            {
                ServerUrl = "http://194.87.92.52:8080";
                WebClient.BaseAddress = new Uri(ServerUrl);
            }

            WebClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/xml");
            CheckServerConnection();
        }

        private async void CheckServerConnection()
        {
            try
            {
                string responseBody = await WebClient.GetStringAsync(ServerUrl);
            }
            catch (Exception ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Ошибка подключения к серверу", ex.Message, "OK");
            }
        }
    }
}
