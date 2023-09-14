using SimplePressureRegulator.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    public partial class MainMenu : ContentPage
    {

        public MainMenu()
        {
            InitializeComponent();
            InternetProductService.EstablishConnection();
        }

        async void StartPressureRegulator(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PressureRegulator1));
        }
        async void StartPulsationDampener(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PulsationDampener1));
        }
        async void StartGPMCalculator(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(GPMCalculator));
        }
        async void StartCvCalculator(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CvCalculator));
        }
        async void StartPressureDropCalculator(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PressureDropCalculator));
        }
    }
}