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
        int? desiredSetPressure;
        int? bodyMaterial;
        int? sealMaterial;
        int? spigotType;
        int? gauge;
        int? valveSize;
        int? maxInletPressure;
        int requiredFlowRate;
        // Declaring variables for selected indeces and required flow rate

        string _valveApplication;
        string _desiredSetPressure;
        string _bodyMaterial;
        string _sealMaterial;
        string _spigotType;
        string _gauge;
        string _valveSize;
        string _maxInletPressure;
        // Declaring variables for getting picker texts

        // START: Picker Methods
        void AssignApplication(object sender, EventArgs args)
        {
            Picker applicationPicker = (Picker)sender;
            valveApplication = applicationPicker.SelectedIndex;

            desiredSetPressurePicker.SelectedItem = null;
            desiredSetPressure = null;
            desiredSetPressurePicker.IsVisible = true;
            materialPicker.Items.Clear();
            bodyMaterial = null;
            materialPicker.IsVisible = true;
            sealMaterialPicker.SelectedItem = null;
            sealMaterial = null;
            spigotTypePicker.Items.Clear();
            spigotType = null;
            gaugePicker.SelectedItem = null;
            gauge = null;
            sizePicker.IsEnabled = false;
            sizePicker.Items.Clear();
            valveSize = null;
            sizePicker.IsVisible = true;
            maxInletPicker.SelectedItem = null;
            maxInletPressure = null;
            maxInletPicker.IsVisible = true;
            FlowRateGrid.IsVisible = true;
            maxInletPicker.IsEnabled = false;
            CalculateButton.IsVisible = true;

            switch (valveApplication)
            {
                case 0: // High Performance Pressure Regulator
                    spigotTypePicker.IsVisible = false;
                    gaugePicker.IsVisible = false;
                    materialPicker.IsVisible = true;
                    materialPicker.Items.Add("PVC");
                    materialPicker.Items.Add("CPVC");
                    materialPicker.Items.Add("Polypro");
                    materialPicker.Items.Add("PTFE");
                    materialPicker.Items.Add("PVDF");
                    sealMaterialPicker.IsVisible = true;
                    sizePicker.IsEnabled = true;
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
                    spigotTypePicker.IsVisible = false;
                    materialPicker.IsVisible = true;
                    materialPicker.Items.Add("PVC");
                    materialPicker.Items.Add("Polypro");
                    sealMaterialPicker.IsVisible = true;
                    sizePicker.IsEnabled = true;
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
                    spigotTypePicker.IsVisible = true;
                    spigotTypePicker.Items.Add("Asahi");
                    spigotTypePicker.Items.Add("GF");
                    spigotTypePicker.Items.Add("IPS");
                    break;
                case 3: // Ultra-Pure Elastomer Free
                    materialPicker.IsVisible = false;
                    sealMaterialPicker.IsVisible = false;
                    gaugePicker.IsVisible = false;
                    spigotTypePicker.IsVisible = true;
                    spigotTypePicker.Items.Add("Asahi");
                    spigotTypePicker.Items.Add("GF");
                    sizePicker.IsEnabled = true;
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
                    spigotTypePicker.IsVisible = true;
                    spigotTypePicker.Items.Add("Asahi");
                    spigotTypePicker.Items.Add("GF");
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
        void AssignSetPressure(object sender, EventArgs args)
        {
            Picker desiredSetPressurePicker = (Picker)sender;
            desiredSetPressure = desiredSetPressurePicker.SelectedIndex;
        }

        void AssignMaterial(object sender, EventArgs args)
        {
            Picker materialPicker = (Picker)sender;
            bodyMaterial = materialPicker.SelectedIndex;
        }

        void AssignSealMaterial(object sender, EventArgs args)
        {
            Picker sealMaterialPicker = (Picker)sender;
            sealMaterial = sealMaterialPicker.SelectedIndex;
        }

        void AssignSpigotType(object sender, EventArgs args)
        {
            Picker spigotTypePicker = (Picker)sender;
            spigotType = spigotTypePicker.SelectedIndex;

            if (spigotType == 0 && valveApplication == 2 || spigotType == 1 && valveApplication == 2)
            {
                sizePicker.Items.Clear();
                valveSize = null;
                sizePicker.IsEnabled = true;
                sizePicker.Items.Add("20 mm");
                sizePicker.Items.Add("25 mm");
                sizePicker.Items.Add("32 mm");
                sizePicker.Items.Add("40 mm");
                sizePicker.Items.Add("50 mm");
                sizePicker.Items.Add("63 mm");
                sizePicker.Items.Add("90 mm");
            }
            else if (spigotType == 2 && valveApplication == 2)
            {
                sizePicker.Items.Clear();
                valveSize = null;
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
            gauge = gaugePicker.SelectedIndex;
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
        }

        void AssignMaxInlet(object sender, EventArgs args)
        {
            Picker maxInletPicker = (Picker)sender;
            maxInletPressure = maxInletPicker.SelectedIndex;
        }
        // END: Picker Methods



        // START: Flow rate entry
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
        // END: Flow rate entry

        async void calculateCheck(object sender, EventArgs args)
        {
            string _requiredFlowRate = requiredFlowRateEntry.Text;            
            _valveApplication = applicationPicker.Items[applicationPicker.SelectedIndex];
            _desiredSetPressure = desiredSetPressurePicker.Items[desiredSetPressurePicker.SelectedIndex];
            try { _bodyMaterial = materialPicker.Items[materialPicker.SelectedIndex]; } catch { }
            try { _sealMaterial = sealMaterialPicker.Items[sealMaterialPicker.SelectedIndex]; } catch { }
            try { _spigotType = spigotTypePicker.Items[spigotTypePicker.SelectedIndex]; } catch{ }
            try { _gauge = gaugePicker.Items[gaugePicker.SelectedIndex]; } catch { }
            _valveSize = sizePicker.Items[sizePicker.SelectedIndex];
            _maxInletPressure = maxInletPicker.Items[maxInletPicker.SelectedIndex];
            try { requiredFlowRate = Int32.Parse(_requiredFlowRate); }
            catch
            {
                await DisplayAlert("Error", "Invalid input", "Okay");
                return;
            }

            switch (valveApplication)
            {
                case 0: // High Performance Pressure Regulator
                    if (desiredSetPressure != null && bodyMaterial != null && sealMaterial != null && valveSize != null && maxInletPressure != null)
                    {
                        await Navigation.PushAsync(new PressureRegulator2(_valveApplication, _desiredSetPressure, _bodyMaterial, _sealMaterial, _spigotType, _gauge, _valveSize, _maxInletPressure, desiredSetPressure, valveSize, maxInletPressure, requiredFlowRate));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a selection", "Okay");
                    }
                    break;
                case 1: // Differential Pressure Regulator
                    if (desiredSetPressure != null && bodyMaterial != null && sealMaterial != null && valveSize != null && maxInletPressure != null)
                    {
                        await Navigation.PushAsync(new PressureRegulator2(_valveApplication, _desiredSetPressure, _bodyMaterial, _sealMaterial, _spigotType, _gauge, _valveSize, _maxInletPressure, desiredSetPressure, valveSize, maxInletPressure, requiredFlowRate));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a selection", "Okay");
                    }
                    break;
                case 2: // PRHU
                    if (desiredSetPressure != null && spigotType != null && valveSize != null && maxInletPressure != null)
                    {
                        await Navigation.PushAsync(new PressureRegulator2(_valveApplication, _desiredSetPressure, _bodyMaterial, _sealMaterial, _spigotType, _gauge, _valveSize, _maxInletPressure, desiredSetPressure, valveSize, maxInletPressure, requiredFlowRate));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a selection", "Okay");
                    }
                    break;
                case 3: // Ultra-Pure Elastomer-Free
                    if (desiredSetPressure != null && spigotType != null && valveSize != null && maxInletPressure != null)
                    {
                        await Navigation.PushAsync(new PressureRegulator2(_valveApplication, _desiredSetPressure, _bodyMaterial, _sealMaterial, _spigotType, _gauge, _valveSize, _maxInletPressure, desiredSetPressure, valveSize, maxInletPressure, requiredFlowRate));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a selection", "Okay");
                    }
                    break;
                case 4: // Ultra-Pure Shutoff Design
                    if (desiredSetPressure != null && spigotType != null && valveSize != null && maxInletPressure != null && gauge != null)
                    {
                        await Navigation.PushAsync(new PressureRegulator2(_valveApplication, _desiredSetPressure, _bodyMaterial, _sealMaterial, _spigotType, _gauge, _valveSize, _maxInletPressure, desiredSetPressure, valveSize, maxInletPressure, requiredFlowRate));
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