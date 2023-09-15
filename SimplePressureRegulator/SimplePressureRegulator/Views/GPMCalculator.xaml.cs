using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GPMCalculator : ContentPage
    {
        public GPMCalculator()
        {
            InitializeComponent();
            BindingContext = this;
        }

        int? valveApplication;
        int? valveSize;
        double specificGravity;
        double inletPressure;
        double outletPressure;

        string _valveApplication;
        string _valveSize;

        void AssignApplication(object sender, EventArgs args)
        {
            Picker applicationPicker = (Picker)sender;
            valveApplication = applicationPicker.SelectedIndex;

            sizePicker.Items.Clear();
            valveSize = null;
            sizePicker.IsVisible = true;
            EntryGrid.IsVisible = true;
            LabelGrid.IsVisible = false;
            CalculateButton.IsVisible = true;
            

            switch (valveApplication)
            {
                case 0: // Ball Valve
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/4\"");
                    sizePicker.Items.Add("1 1/2\"");
                    sizePicker.Items.Add("2\"");
                    sizePicker.Items.Add("3\"");
                    sizePicker.Items.Add("4\"");
                    MaxInlet = "185";
                    MaxOutlet = "185";
                    break;
                case 1: // Solenoid Valve EASMT
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    break;
                case 2: // Solenoid Valve PS
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/2\"");
                    sizePicker.Items.Add("2\"");
                    sizePicker.Items.Add("3\"");
                    MaxInlet = "140";
                    MaxOutlet = "70";
                    break;
                case 3: // Globe Style Shutoff Valve
                    sizePicker.Items.Add("1/4\"");
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/2\"");
                    MaxInlet = "100";
                    MaxOutlet = "25";
                    break;
            }
        }
        void AssignPipeSize(object sender, EventArgs args)
        {
            Picker sizePicker = (Picker)sender;
            valveSize = sizePicker.SelectedIndex;
            LabelGrid.IsVisible = true;

            if (valveApplication == 1)
            {
                switch (valveSize)
                {
                    case 0:
                        MaxInlet = "125";
                        MaxOutlet = "18";
                        break;
                    case 1:
                        MaxInlet = "58";
                        MaxOutlet = "17";
                        break;
                    case 2:
                        MaxInlet = "15";
                        MaxOutlet = "12";
                        break;
                }
            }

        }

        string _specificGravity = "1";
        string _inletPressure = "";
        string _outletPressure = "";
        string _maxInlet = "";
        string _maxOutlet = "";
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
        public string MaxInlet
        {
            get => _maxInlet + " PSI";
            set
            {
                if (_maxInlet != value)
                {
                    _maxInlet = value;
                    OnPropertyChanged(nameof(MaxInlet));
                }
            }
        }
        public string MaxOutlet
        {
            get => _maxOutlet + " PSI";
            set
            {
                if (_maxOutlet != value)
                {
                    _maxOutlet = value;
                    OnPropertyChanged(nameof(MaxOutlet));
                }
            }
        }


        async void calculateCheck(object sender, EventArgs args)
        {
            string _specificGravity = GravityEntry.Text;
            string _inletPressure = InletEntry.Text;
            string _outletPressure = OutletEntry.Text;
            try { _valveApplication = applicationPicker.Items[applicationPicker.SelectedIndex]; } catch { }
            try { _valveSize = sizePicker.Items[sizePicker.SelectedIndex]; } catch { }
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
                await DisplayAlert("Error", "Inlet pressure must be greater than outlet pressure", "Okay");
                return;
            }
            if (inletPressure > double.Parse(_maxInlet))
            {
                await DisplayAlert("Error", "Your inlet pressure cannot be greater than the maximum inlet pressure", "Okay");
                return;
            }
            if (outletPressure > double.Parse(_maxOutlet))
            {
                await DisplayAlert("Error", "Your outlet pressure cannot be greater than the maximum outlet pressure", "Okay");
                return;
            }
            if (specificGravity <= 0)
            {
                await DisplayAlert("Error", "Specific Gravity must be greater than 0.", "Okay");
                return;
            }
            if (inletPressure < 0 || outletPressure < 0)
            {
                await DisplayAlert("Error", "Pressure values cannot be negative.", "Okay");
                return;
            }


            if (valveApplication != null && valveSize != null)
            {
                await Navigation.PushAsync(new GPMCalculator2(_valveApplication, _valveSize, _specificGravity, valveApplication, valveSize, specificGravity, inletPressure, outletPressure));
            }
            else
            {
                await DisplayAlert("Error", "Please make a selection", "Okay");
            }      
        }
    }
}