using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PressureDropCalculator : ContentPage
    {
        public PressureDropCalculator()
        {
            InitializeComponent();
            BindingContext = this;
        }

        int? valveApplication;
        int? valveSize;
        double specificGravity;
        double gpm;

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
                    break;
                case 3: // Globe Style Shutoff Valve
                    sizePicker.Items.Add("1/4\"");
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/2\"");
                    break;
            }
        }
        void AssignPipeSize(object sender, EventArgs args)
        {
            Picker sizePicker = (Picker)sender;
            valveSize = sizePicker.SelectedIndex;
        }

        string _specificGravity = "1";
        string _gpm = "";
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
       
        async void calculateCheck(object sender, EventArgs args)
        {
            string _specificGravity = GravityEntry.Text;
            string _gpm = GPMEntry.Text;
            
            try { _valveApplication = applicationPicker.Items[applicationPicker.SelectedIndex]; } catch { }
            try { _valveSize = sizePicker.Items[sizePicker.SelectedIndex]; } catch { }
            try { specificGravity = double.Parse(_specificGravity); }
            catch
            {
                await DisplayAlert("Error", "Please enter a valid specific gravity.", "Okay");
                return;
            }
            try { gpm = double.Parse(_gpm); }
            catch
            {
                await DisplayAlert("Error", "Please enter a valid flow rate.", "Okay");
                return;
            }
            if (specificGravity <= 0)
            {
                await DisplayAlert("Error", "Specific Gravity must be greater than 0.", "Okay");
                return;
            }
            if (gpm <0)
            {
                await DisplayAlert("Error", "Flow rate cannot be negative.", "Okay");
                return;
            }


            if (valveApplication != null && valveSize != null)
            {
                await Navigation.PushAsync(new PressureDropCalculator2(_valveApplication, _valveSize, _specificGravity, valveApplication, valveSize, specificGravity, gpm));
            }
            else
            {
                await DisplayAlert("Error", "Please make a selection", "Okay");
            }
        }
    }
}