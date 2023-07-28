using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PressureRegulator1 : ContentPage
    {
        public PressureRegulator1()
        {
            InitializeComponent();
            BindingContext = this;
        }

        int? valveApplication;
        int? valveBodyMaterial;
        int? valveSealMaterial;
        int? connectionType;
        int? gaugeType;
        int? valveSize;
        int? _desiredSetPressure;
        int? maxInletPressure;

        void AssignApplication(object sender, EventArgs args)
        {
            Picker applicationPicker = (Picker)sender;
            valveApplication = applicationPicker.SelectedIndex;
            // Assigns the application chosen by the user in the dropdown menu. Index 0 is standard pressure regulator, etc...

            DesiredSetPressurePicker.SelectedItem = null;
            _desiredSetPressure = null;
            DesiredSetPressurePicker.IsVisible = true;
            materialPicker.Items.Clear();
            valveBodyMaterial = null;
            materialPicker.IsVisible = true;
            sealMaterialPicker.SelectedItem = null;
            valveSealMaterial = null;
            connectionTypePicker.SelectedItem = null;
            connectionType = null;
            gaugePicker.SelectedItem = null;
            gaugeType = null;
            sizePicker.Items.Clear();
            valveSize = null;
            sizePicker.IsVisible = true;
            maxInletPicker.SelectedItem = null;
            maxInletPressure = null;
            maxInletPicker.IsVisible = true;
            FlowRateGrid.IsVisible = true;
            maxInletPicker.IsEnabled = false;
            CalculateButton.IsVisible = true;
            // Clears all previously selected inputs when the user makes a selection

            // Showing the right fields based on valve application
            switch (valveApplication)
            {
                case 0: // High Performance Pressure Regulator
                    connectionTypePicker.IsVisible = false;
                    gaugePicker.IsVisible = false;
                    materialPicker.IsVisible = true;
                    materialPicker.Items.Add("PVC");
                    materialPicker.Items.Add("CPVC");
                    materialPicker.Items.Add("Polypro");
                    materialPicker.Items.Add("PTFE");
                    materialPicker.Items.Add("PVDF");
                    sealMaterialPicker.IsVisible = true;
                    sizePicker.Items.Add("1/4\"");
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/2\"");
                    sizePicker.Items.Add("2\"");
                    sizePicker.Items.Add("3\"");
                    break;
                case 1: // Differential Pressure Regulator
                    gaugePicker.IsVisible = false;
                    connectionTypePicker.IsVisible = false;
                    materialPicker.IsVisible = true;
                    materialPicker.Items.Add("PVC");
                    materialPicker.Items.Add("Polypro");
                    sealMaterialPicker.IsVisible = true;
                    sizePicker.Items.Add("1/4\"");
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/2\"");
                    sizePicker.Items.Add("2\"");
                    sizePicker.Items.Add("3\"");
                    break;
                case 2: // Ultra-Pure Metal Ion-Free EPDM
                    materialPicker.IsVisible = false;
                    sealMaterialPicker.IsVisible = false;
                    gaugePicker.IsVisible = false;
                    connectionTypePicker.IsVisible = true;
                    break;
                case 3: // Ultra-Pure Elastomer Free
                    materialPicker.IsVisible = false;
                    sealMaterialPicker.IsVisible = false;
                    gaugePicker.IsVisible = false;
                    connectionTypePicker.IsVisible = true;
                    sizePicker.Items.Add("1/4\"");
                    sizePicker.Items.Add("20 mm");
                    sizePicker.Items.Add("25 mm");
                    sizePicker.Items.Add("32 mm");
                    sizePicker.Items.Add("50 mm");
                    sizePicker.Items.Add("63 mm");
                    break;
                case 4: // Ultra-Pure Shutoff Design
                    materialPicker.IsVisible = false;
                    sealMaterialPicker.IsVisible = false;
                    connectionTypePicker.IsVisible = true;
                    gaugePicker.IsVisible = true;
                    sizePicker.IsEnabled = true;
                    sizePicker.Items.Add("20 mm");
                    sizePicker.Items.Add("25 mm");
                    sizePicker.Items.Add("32 mm");
                    sizePicker.Items.Add("50 mm");
                    sizePicker.Items.Add("63 mm");
                    break;
            }
        }

        // The following code will grab what the user selects in the dropdown menus and store the correct index as a variable
        void AssignSetPressure(object sender, EventArgs args)
        {
            Picker DesiredSetPressurePicker = (Picker)sender;
            _desiredSetPressure = DesiredSetPressurePicker.SelectedIndex;
        }

        void AssignMaterial(object sender, EventArgs args)
        {
            Picker materialPicker = (Picker)sender;
            valveBodyMaterial = materialPicker.SelectedIndex;
        }

        void AssignSealMaterial(object sender, EventArgs args)
        {
            Picker sealMaterialPicker = (Picker)sender;
            valveSealMaterial = sealMaterialPicker.SelectedIndex;
        }

        void AssignConnectionType(object sender, EventArgs args)
        {
            Picker connectionTypePicker = (Picker)sender;
            connectionType = connectionTypePicker.SelectedIndex;

            if (connectionType == 0 && valveApplication == 2 || connectionType == 1 && valveApplication == 2)
            {
                sizePicker.Items.Clear();
                sizePicker.IsEnabled = true;
                sizePicker.Items.Add("20 mm");
                sizePicker.Items.Add("25 mm");
                sizePicker.Items.Add("32 mm");
                sizePicker.Items.Add("40 mm");
                sizePicker.Items.Add("50 mm");
                sizePicker.Items.Add("63 mm");
                sizePicker.Items.Add("90 mm");
            }
            else if (connectionType == 2 && valveApplication == 2)
            {
                sizePicker.Items.Clear();
                sizePicker.IsEnabled = true;
                sizePicker.Items.Add("1/2\"");
                sizePicker.Items.Add("3/4\"");
                sizePicker.Items.Add("1\"");
                sizePicker.Items.Add("1 1/4\"");
                sizePicker.Items.Add("1 1/2\"");
                sizePicker.Items.Add("2\"");
                sizePicker.Items.Add("3\"");
            }
        }

        void AssignGauge(object sender, EventArgs args)
        {
            Picker gaugePicker = (Picker)sender;
            gaugeType = gaugePicker.SelectedIndex;
        }

        void AssignPipeSize(object sender, EventArgs args)
        {
            Picker sizePicker = (Picker)sender;
            valveSize = sizePicker.SelectedIndex;
            maxInletPicker.Items.Clear();
            maxInletPressure = null;
            maxInletPicker.IsEnabled = true;
            switch (valveSize)
            {
                case 0: // 1/4"
                    maxInletPicker.Items.Add("15 PSI");
                    maxInletPicker.Items.Add("30 & Up");
                    break;
                case 1: // 1/2"
                    maxInletPicker.Items.Add("15 PSI");
                    maxInletPicker.Items.Add("30 & Up");
                    break;
                case 2: // 3/4"
                    maxInletPicker.Items.Add("10 PSI");
                    maxInletPicker.Items.Add("25 & Up");
                    break;
                case 3: // 1"
                    maxInletPicker.Items.Add("10 PSI");
                    maxInletPicker.Items.Add("25 & Up");
                    break;
                case 4: // 1 1/2"
                    maxInletPicker.Items.Add("10 PSI");
                    maxInletPicker.Items.Add("25 & Up");
                    break;
                case 5: // 2"
                    maxInletPicker.Items.Add("10 PSI");
                    maxInletPicker.Items.Add("25 & Up");
                    break;
                case 6: // 3"
                    maxInletPicker.Items.Add("10 PSI");
                    maxInletPicker.Items.Add("25 & Up");
                    break;
                case 7: // Extra for 1 1/4"
                    maxInletPicker.Items.Add("10 PSI");
                    maxInletPicker.Items.Add("25 & Up");
                    break;
            }

            // Making sure that we send the right index number for calculating Max Flow Rate.
            if (valveApplication == 2 && valveSize < 4)
            {
                valveSize += 1; // We add 1 to account for 1/4" pipe size not being in the selection. Selection starts at 1/2"
            }
            if (valveApplication == 4)
            {
                valveSize += 1; // We add 1 to account for 1/4" pipe size not being in the selection. Selection starts at 20mm AKA 1/2"
            }
        }

        void AssignMaxInlet(object sender, EventArgs args)
        {
            Picker maxInletPicker = (Picker)sender;
            maxInletPressure = maxInletPicker.SelectedIndex;

        }


        int _requiredFlowRate;

        string flowRate = "";
        public string FlowRate
        {
            get => flowRate;
            set
            {
                if (value == null || value == "")
                {
                    requiredFlowRateLabel1.TextColor = Color.FromHex("#0000EE");
                    requiredFlowRateLabel2.TextColor = Color.FromHex("#0000EE");
                    return;
                }
                else
                {
                    flowRate = value;
                    requiredFlowRateLabel1.TextColor = Color.Black;
                    requiredFlowRateLabel2.TextColor = Color.Black;
                    OnPropertyChanged(nameof(FlowRate));
                }              
            }
        }

        async void calculateCheck(object sender, EventArgs args)
        {
            string __requiredFlowRate = requiredFlowRate.Text;

            try
            {
                _requiredFlowRate = Int32.Parse(__requiredFlowRate);
            }
            catch (Exception e)
            {
                await DisplayAlert("Error", "Invalid input", "Okay");
                return;
            }

            switch (valveApplication)
            {
                case 0: // High Performance Pressure Regulator
                    if (_desiredSetPressure != null && valveBodyMaterial != null && valveSealMaterial != null && valveSize != null && maxInletPressure != null)
                    {
                        await Navigation.PushAsync(new PressureRegulator2(maxInletPressure, _desiredSetPressure, _requiredFlowRate, valveApplication, valveBodyMaterial, valveSealMaterial, connectionType, gaugeType, valveSize));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a selection", "Okay");
                    }
                    break;
                case 1: // Differential Pressure Regulator
                    if (_desiredSetPressure != null && valveBodyMaterial != null && valveSealMaterial != null && valveSize != null && maxInletPressure != null)
                    {
                        await Navigation.PushAsync(new PressureRegulator2(maxInletPressure, _desiredSetPressure, _requiredFlowRate, valveApplication, valveBodyMaterial, valveSealMaterial, connectionType, gaugeType, valveSize));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a selection", "Okay");
                    }
                    break;
                case 2: // PRHU
                    if (_desiredSetPressure != null && connectionType != null && valveSize != null && maxInletPressure != null)
                    {
                        await Navigation.PushAsync(new PressureRegulator2(maxInletPressure, _desiredSetPressure, _requiredFlowRate, valveApplication, valveBodyMaterial, valveSealMaterial, connectionType, gaugeType, valveSize));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a selection", "Okay");
                    }
                    break;
                case 3: // Ultra-Pure Elastomer-Free
                    if (_desiredSetPressure != null && connectionType != null && valveSize != null && maxInletPressure != null)
                    {
                        await Navigation.PushAsync(new PressureRegulator2(maxInletPressure, _desiredSetPressure, _requiredFlowRate, valveApplication, valveBodyMaterial, valveSealMaterial, connectionType, gaugeType, valveSize));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a selection", "Okay");
                    }
                    break;
                case 4: // Ultra-Pure Shutoff Design
                    if (_desiredSetPressure != null && connectionType != null && valveSize != null && maxInletPressure != null && gaugeType != null)
                    {
                        await Navigation.PushAsync(new PressureRegulator2(maxInletPressure, _desiredSetPressure, _requiredFlowRate, valveApplication, valveBodyMaterial, valveSealMaterial, connectionType, gaugeType, valveSize));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a selection", "Okay");
                    }
                    break;
            }
        }
    }
}