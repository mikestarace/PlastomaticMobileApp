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
    public partial class PressureDropCalculator2 : ContentPage
    {
        string _pressureDrop;
        string url;
        public PressureDropCalculator2(string _valveApplication, string _valveSize, string _specificGravity, int? valveApplication, int? valveSize, double specificGravity, double gpm)
        {
            InitializeComponent();
            BindingContext = this;
            ValveApplicationLabel.Text = _valveApplication;
            ValveSizeLabel.Text = _valveSize;
            GravityLabel.Text = _specificGravity;
            GPMLabel.Text = gpm.ToString() + " GPM";
            

            double cvFactor = 0;

            switch (valveApplication)
            {
                case 0: // Ball Valve
                    url = "https://plastomatic.com/products/category/ball-valves/";
                    BrowseButton.Text = "Browse Ball Valves";
                    switch (valveSize)
                    {
                        case 0:
                            cvFactor = 10;
                            break;
                        case 1:
                            cvFactor = 20;
                            break;
                        case 2:
                            cvFactor = 40;
                            break;
                        case 3:
                            cvFactor = 80;
                            break;
                        case 4:
                            cvFactor = 100;
                            break;
                        case 5:
                            cvFactor = 120;
                            break;
                        case 6:
                            cvFactor = 490;
                            break;
                        case 7:
                            cvFactor = 770;
                            break;
                    }
                    break;
                case 1: // Solenoid Valve EASMT
                    url = "https://plastomatic.com/products/category/solenoid-valves/normally-closed-solenoid-valves-energize-to-open/multi-purpose-direct-acting-valves-wptfe-bellows-z-cool-coil/";
                    BrowseButton.Text = "Browse Direct Acting Solenoid Valves";
                    switch (valveSize)
                    {
                        case 0:
                            cvFactor = 2;
                            break;
                        case 1:
                            cvFactor = 3.2;
                            break;
                        case 2:
                            cvFactor = 4.2;
                            break;
                    }
                    break;
                case 2: // Solenoid Valve PS
                    url = "https://plastomatic.com/products/category/solenoid-valves/normally-closed-solenoid-valves-energize-to-open/high-flow-pilot-operated-valves-w-ptfe-bellows/";
                    BrowseButton.Text = "Browse Pilot Operated Solenoid Valves";
                    switch (valveSize)
                    {
                        case 0:
                            cvFactor = 5.2;
                            break;
                        case 1:
                            cvFactor = 7.6;
                            break;
                        case 2:
                            cvFactor = 9.5;
                            break;
                        case 3:
                            cvFactor = 28;
                            break;
                        case 4:
                            cvFactor = 35;
                            break;
                        case 5:
                            cvFactor = 80;
                            break;
                    }
                    break;
                case 3: // Globe Style Shutoff Valve
                    url = "https://plastomatic.com/products/category/shut-off-and-diverter-valves/air-operated-shut-off-valves/compact-ptfe-diaphragm-shut-off-valve/";
                    BrowseButton.Text = "Browse Globe Style Shutoff Valves";
                    switch (valveSize)
                    {
                        case 0:
                            cvFactor = 1.1;
                            break;
                        case 1:
                            cvFactor = 3.4;
                            break;
                        case 2:
                            cvFactor = 5.8;
                            break;
                        case 3:
                            cvFactor = 6.3;
                            break;
                        case 4:
                            cvFactor = 17;
                            break;
                    }
                    break;
            }
            CvFactorLabel.Text = cvFactor.ToString();

            _pressureDrop = Math.Round(Math.Pow(gpm / cvFactor, 2) * specificGravity, 2).ToString();

            PressureDropLabel.Text = "Pressure Drop: " + _pressureDrop + " PSI";


        } // End of Main Method

        async void CopyToClipboard(object sender, EventArgs args)
        {
            await Clipboard.SetTextAsync(_pressureDrop);
            await DisplayAlert("", "Copied to Clipboard", "Okay");
        }
        private async void OnTapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync(url);
        }
    }
}