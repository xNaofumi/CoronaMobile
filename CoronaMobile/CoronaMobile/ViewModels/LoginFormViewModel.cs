using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using CoronaMobile.Views;

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
            var content = new StringContent($"password={Password},email={PhoneNumberOrEmail}");

            try
            {
                var response = await App.WebClient.PostAsync(App.WebClient.BaseAddress, content);
                await Shell.Current.CurrentPage.DisplayAlert("Ответ", response.Content.ReadAsStringAsync().Result, "OK");
                await Shell.Current.CurrentPage.DisplayAlert("Ответ", response.StatusCode.ToString(), "OK");
                
                
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            catch (Exception ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Ошибка подключения", ex.Message, "OK");
            }
        }
    }
}