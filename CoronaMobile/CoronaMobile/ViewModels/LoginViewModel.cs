using CoronaMobile.Views;
using Xamarin.Forms;

namespace CoronaMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public Command AppSettingsCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            AppSettingsCommand = new Command(OnSettingsClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(LoginFormPage)}");
        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterFormPage)}");
        }

        private async void OnSettingsClicked(object obj)
        {
            await Shell.Current.Navigation.PushAsync(new SettingsPage());
        }
    }
}
