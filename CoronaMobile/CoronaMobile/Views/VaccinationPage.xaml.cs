using CoronaMobile.ViewModels;
using Xamarin.Forms;

namespace CoronaMobile.Views
{
    public partial class VaccinationPage : ContentPage
    {
        private VaccinationViewModel _viewModel;

        public VaccinationPage()
        {
            InitializeComponent();

            _viewModel = new VaccinationViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}