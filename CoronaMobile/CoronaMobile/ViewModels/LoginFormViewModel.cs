using CoronaMobile.Views;
using System;
using Xamarin.Forms;

namespace CoronaMobile.ViewModels
{
    public class LoginFormViewModel : BaseViewModel
    {
        public Command AuthorizeCommand { get; }
        public string PhoneNumberOrEmail
        { 
            get => _phoneNumberOrEmail; 
            set => SetProperty(ref _phoneNumberOrEmail, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _phoneNumberOrEmail;
        private string _password;

        public LoginFormViewModel()
        {
            AuthorizeCommand = new Command(TryAuthorize, ValidateAuthorize);
            this.PropertyChanged +=
                (_, __) => AuthorizeCommand.ChangeCanExecute();
        }

        private bool ValidateAuthorize()
        {
            return  !String.IsNullOrWhiteSpace(_phoneNumberOrEmail) &&
                    !String.IsNullOrWhiteSpace(_password);
        }

        private async void TryAuthorize()
        {
            try
            {
                // Server API is not ready so we are assuming user has authorized successfully.
                await Shell.Current.CurrentPage.DisplayAlert("Вход", "Вы успешно вошли.", "OK");
                await Shell.Current.Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Ошибка подключения", ex.Message, "OK");
            }
        }
    }
}