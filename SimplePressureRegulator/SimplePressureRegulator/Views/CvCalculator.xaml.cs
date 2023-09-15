using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CvCalculator : ContentPage
    {
        public CvCalculator()
        {
            InitializeComponent();
            BindingContext = this;
        }

        double gpm;
        double specificGravity;
        double inletPressure;
        double outletPressure;

        string _gpm = "";
        string _specificGravity = "1";
        string _inletPressure = "";
        string _outletPressure = "";
        public string GPM
        {
            get => _gpm;
            set
            {
                if (value == null || value == "")
                {
                    GPMLabel.TextColor = Color.FromHex("#0000EE");
                    GPMLabel2.TextColor = Color.FromHex("#0000EE");
                    return;
                }
                else
                {
                    _gpm = value;
                    GPMLabel.TextColor = Color.Black;
                    GPMLabel2.TextColor = Color.Black;
                    OnPropertyChanged(nameof(GPM));
                }
            }
        }
        public string SpecificGravity
        {
            get => _specificGravity;
            set
            {
                if (value == null || value == "")
                {
                    GravityLabel.TextColor = Color.FromHex("#0000EE");
                    return;
                }
                else
                {
                    _specificGravity = value;
                    GravityLabel.TextColor = Color.Black;
                    OnPropertyChanged(nameof(SpecificGravity));
                }
            }
        }
        public string InletPressure
        {
            get => _inletPressure;
            set
            {
                if (value == null || value == "")
                {
                    InletLabel.TextColor = Color.FromHex("#0000EE");
                    InletLabel2.TextColor = Color.FromHex("#0000EE");
                    return;
                }
                else
                {
                    _inletPressure = value;
                    InletLabel.TextColor = Color.Black;
                    InletLabel2.TextColor = Color.Black;
                    OnPropertyChanged(nameof(InletPressure));
                }
            }
        }
        public string OutletPressure
        {
            get => _outletPressure;
            set
            {
                if (value == null || value == "")
                {
                    OutletLabel.TextColor = Color.FromHex("#0000EE");
                    OutletLabel2.TextColor = Color.FromHex("#0000EE");
                    return;
                }
                else
                {
                    _outletPressure = value;
                    OutletLabel.TextColor = Color.Black;
                    OutletLabel2.TextColor = Color.Black;
                    OnPropertyChanged(nameof(OutletPressure));
                }
            }
        }


        async void calculateCheck(object sender, EventArgs args)
        {
            string _gpm = GPMEntry.Text;
            string _specificGravity = GravityEntry.Text;
            string _inletPressure = InletEntry.Text;
            string _outletPressure = OutletEntry.Text;
            try { gpm = double.Parse(_gpm); }
            catch
            {
                await DisplayAlert("Error", "Please enter a valid GPM.", "Okay");
                return;
            }
            try { specificGravity = double.Parse(_specificGravity); }
            catch
            {
                await DisplayAlert("Error", "Please enter a valid specific gravity.", "Okay");
                return;
            }
            try { inletPressure = double.Parse(_inletPressure); }
            catch
            {
                await DisplayAlert("Error", "Please enter a valid inlet pressure.", "Okay");
                return;
            }
            try { outletPressure = double.Parse(_outletPressure); }
            catch
            {
                await DisplayAlert("Error", "Please enter a valid outlet pressure.", "Okay");
                return;
            }

            if (outletPressure >= inletPressure)
            {
                await DisplayAlert("Error", "Inlet pressure must be greater than outlet pressure.", "Okay");
                return;
            }
            if (specificGravity <= 0)
            {
                await DisplayAlert("Error", "Specific Gravity must be greater than 0.", "Okay");
                return;
            }
            if (inletPressure < 0 || outletPressure < 0 || gpm < 0)
            {
                await DisplayAlert("Error", "GPM and pressure values cannot be negative.", "Okay");
                return;
            }

            await Navigation.PushAsync(new CvCalculator2(_gpm, _specificGravity, gpm, specificGravity, inletPressure, outletPressure));
        }
    }
}