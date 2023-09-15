using MvvmHelpers;
using SimplePressureRegulator.Models;
using SimplePressureRegulator.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CvCalculator2 : ContentPage
    {
        string _cvFactor;

        public CvCalculator2(string _gpm, string _specificGravity, double gpm, double specificGravity, double inletPressure, double outletPressure)
        {
            InitializeComponent();
            BindingContext = this;
            GPMLabel.Text = _gpm;
            GravityLabel.Text = _specificGravity;
            double pressureDrop = inletPressure - outletPressure;
            PressureDropLabel.Text = Math.Round(pressureDrop, 1).ToString();
            _cvFactor = Math.Round(gpm / Math.Sqrt(pressureDrop / specificGravity), 1).ToString();

            CvLabel.Text = "Cv Factor: " + _cvFactor;
        }

        async void CopyToClipboard(object sender, EventArgs args)
        {
            await Clipboard.SetTextAsync(_cvFactor);
            await DisplayAlert("", "Copied to Clipboard", "Okay");
        }
    }
}