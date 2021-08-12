using System;
using System.Net.Http;

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
            // Server API only has register feature finished, so this is playing role of
            // testing purposes only.

            var request = new HttpRequestMessage(HttpMethod.Post, App.WebClient.BaseAddress + "patient/register");
            var content = new StringContent("<PatientRegData>" +
                $"<firstName>{_firstName}</firstName>" +
                $"<lastName>{_lastName}</lastName>" +
                $"<email>{_email}</email>" +
                $"<password>{_password}</password>" +
                $"<phoneNumber>{_phoneNumber}</phoneNumber>" +
                $"<birthDate>{_birthDate}</birthDate>" +
                $"</PatientRegData>");

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/xml");
            request.Content = content;

            try
            {
                var response = await App.WebClient.SendAsync(request);
                var responseResult = await response.Content.ReadAsStringAsync();
                await Shell.Current.CurrentPage.DisplayAlert("Ответ", response.StatusCode.ToString(), "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}