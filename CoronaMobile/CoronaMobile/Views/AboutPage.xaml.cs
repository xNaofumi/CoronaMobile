using CoronaMobile.Models;
using CoronaMobile.ViewModels;
using Xamarin.Forms;

namespace CoronaMobile.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            UpdateCovidStats();

            BindingContext = new LoginViewModel();
        }

        public async void UpdateCovidStats()
        {
            var info = new CovidInfo();

            CovidInfo.Stats stats;

            try
            {
                stats = await info.GetStatsAsync();
            } catch {
                await DisplayAlert("Не удалось подключиться", "Отсутствует соединение с сайтом стопкоронавирус.рф. " +
                    "Проверьте подключение к сети Интернет.", "OK");

                return;
            }

            Stats_InfectionsLastDay.Text = stats.InfectionsLastDay;
            Stats_Infections.Text = stats.Infections;
            Stats_Died.Text = stats.Died;
            Stats_Recovered.Text = stats.Recovered;
            Stats_Tests.Text = stats.Tests;
        }
    }
}