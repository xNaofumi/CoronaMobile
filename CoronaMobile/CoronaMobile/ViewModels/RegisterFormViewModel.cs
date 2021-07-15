using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;

namespace CoronaMobile.ViewModels
{
    public class RegisterFormViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public string BirthDate
        {
            get => _birthDate;
            set => SetProperty(ref _birthDate, value);
        }

        private string _phoneNumber;
        private string _email;
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _birthDate;

        public RegisterFormViewModel()
        {
            RegisterCommand = new Command(TryRegister, ValidateRegister);
            this.PropertyChanged +=
                (_, __) => RegisterCommand.ChangeCanExecute();
            this.PropertyChanged +=
                (_, __) => FormatFields();
        }

        private void FormatFields()
        {
            
        }

        private bool ValidateRegister()
        {
            return !String.IsNullOrWhiteSpace(_phoneNumber) &&
                   !String.IsNullOrWhiteSpace(_password) &&
                   !String.IsNullOrWhiteSpace(_email) &&
                   !String.IsNullOrWhiteSpace(_firstName) &&
                   !String.IsNullOrWhiteSpace(_lastName) &&
                   !String.IsNullOrWhiteSpace(_birthDate);
        }

        private async void TryRegister()
        {
            var content = new StringContent($"firstName={_firstName},secondName={_lastName},email={_email},password={_password}," +
                $"phoneNumber={_phoneNumber},birthDate={_birthDate}");

            try
            {
                var response = await App.WebClient.PostAsync(App.WebClient.BaseAddress, content);
                await Shell.Current.CurrentPage.DisplayAlert("Ответ", response.Content.ReadAsStringAsync().Result, "OK");
                await Shell.Current.CurrentPage.DisplayAlert("Ответ", response.StatusCode.ToString(), "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Ошибка подключения", ex.Message, "OK");
            }
        }
    }
}