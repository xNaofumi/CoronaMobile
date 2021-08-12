using CoronaMobile.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoronaMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command MainPageCommand { get; }

        public AboutViewModel()
        {
            Title = "Приветствие";

            MainPageCommand = new Command(async () => await Shell.Current.Navigation.PushModalAsync(new MainPage()));
        }
    }
}