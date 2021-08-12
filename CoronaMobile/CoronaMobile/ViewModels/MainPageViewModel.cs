using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using CoronaMobile.Views;

namespace CoronaMobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public Command AppSettingsCommand { get; }
        public Command VaccinationCommand { get; }
        public Command DoctorCommand { get; }
        public Command RedButtonCommand { get; }

        public MainPageViewModel()
        {
            AppSettingsCommand = new Command(async () => await Shell.Current.Navigation.PushAsync(new SettingsPage()));
            VaccinationCommand = new Command(async () => await Shell.Current.Navigation.PushAsync(new VaccinationPage()));
            DoctorCommand = new Command(async () => await Shell.Current.Navigation.PushAsync(new DoctorPage()));

            // This feature is not implemented yet.
            RedButtonCommand = new Command(async () => await Shell.Current.CurrentPage.DisplayAlert(
                "Функционал недоступен", "Вы не являетесь пациентом больницы.", "OK"));
        }
    }
}