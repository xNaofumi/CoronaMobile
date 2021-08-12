using CoronaMobile.Models;
using CoronaMobile.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CoronaMobile.ViewModels
{
    public class VaccinationViewModel : BaseViewModel
    {
        public ObservableCollection<Hospital> Hospitals { get; }
        public Command LoadHospitalsCommand { get; }
        public Command<Hospital> OpenHospitalCommand { get; }

        private Hospital _selectedHospital;

        public VaccinationViewModel()
        {
            Hospitals = new ObservableCollection<Hospital>();
            LoadHospitalsCommand = new Command(LoadHospitals);
            OpenHospitalCommand = new Command<Hospital>(OnHospitalSelected);
        }

        private void LoadHospitals()
        {
            // Server API is not ready so we are using some predetermined list of hospitals.
            Hospitals.Clear();
            Hospitals.Add(new Hospital { Name = "Поликлиника №114", Id = "0", Address = "ул. Ольховая д. 6" });
            Hospitals.Add(new Hospital { Name = "Поликлиника №121", Id = "1", Address = "ул. Камышовая д. 50"});
            Hospitals.Add(new Hospital { Name = "Поликлиника №107", Id = "2", Address = "ул. Энтузиастов д. 16/2" });
            Hospitals.Add(new Hospital { Name = "Поликлиника №62", Id = "3", Address = "ул. Руставелли д. 2" });
            IsBusy = false;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public Hospital SelectedHospital
        {
            get => _selectedHospital;
            set
            {
                SetProperty(ref _selectedHospital, value);
                OnHospitalSelected(value);
            }
        }

        private async void OnHospitalSelected(Hospital hospital)
        {
            if (hospital == null) throw new NullReferenceException();

            await Shell.Current.Navigation.PushModalAsync(new ItemDetailPage(hospital));
        }
    }
}