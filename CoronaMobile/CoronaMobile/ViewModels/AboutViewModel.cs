using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using CoronaMobile.Models;

namespace CoronaMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        public AboutViewModel()
        {
            Title = "Приветствие";
            GoToMainMenu = new Command(async () => await Shell.Current.GoToAsync($"///{nameof(CoronaMobile.Views.ItemsPage)}"));
        }

        public ICommand GoToMainMenu { get; }
    }
}