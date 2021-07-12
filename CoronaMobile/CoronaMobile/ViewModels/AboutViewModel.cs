using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using CoronaMobile.Models;
using CoronaMobile.Views;

namespace CoronaMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        public AboutViewModel()
        {
            Title = "Приветствие";

            GoToMainMenu = new Command(async () => await Shell.Current.Navigation.PushModalAsync(new MainPage()));
        }

        public ICommand GoToMainMenu { get; }
    }
}