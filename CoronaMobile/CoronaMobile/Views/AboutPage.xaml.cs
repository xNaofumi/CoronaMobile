using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoronaMobile.Models;

namespace CoronaMobile.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            UpdateCovidStats();
        }

        public async void UpdateCovidStats()
        {
            var stats = new CovidInfo();

            var info = await stats.GetStatsAsync();
            if (info == null)
            {
                await DisplayAlert("Не удалось подключиться", "Отсутствует соединение с сайтом стопкоронавирус.рф. Проверьте подключение к сети Интернет.", "OK");
                return;
            }

            Stats_InfectionsLastDay.Text = info.InfectionsLastDay;
            Stats_Infections.Text = info.Infections;
            Stats_Died.Text = info.Died;
            Stats_Recovered.Text = info.Recovered;
            Stats_Tests.Text = info.Tests;
        }
    }
}