using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cafe : ContentPage
    {
        public Cafe()
        {
            InitializeComponent();
            BindingContext = this;
        }

        int? valveType;
        int? oledDisplay;
        int? actuatorSpeed;
        int? controlOptions;
        int? connectionType;
        int? valveSize;
        int? bodyMaterial;
        int? sealMaterial;
        int? ballOptions;
        string __actuatorSpeed;
        string __connectionType;
        string __controlOptions;
        string __valveSize;
        string __bodyMaterial;
        string __ballOptions;
        // Declaring variables for selected indeces

        // START: Picker Methods
        void AssignType(object sender, EventArgs args)
        {
            Picker typePicker = (Picker)sender;
            valveType = typePicker.SelectedIndex;
            oledPicker.SelectedItem = null;
            oledDisplay = null;
            oledPicker.IsVisible = true;
            speedPicker.Items.Clear();
            actuatorSpeed = null;
            speedPicker.IsVisible = false;
            controlOptionsPicker.SelectedItem = null;
            controlOptions = null;
            controlOptionsPicker.IsVisible = false;
            connectionPicker.Items.Clear();
            connectionType = null;
            connectionPicker.IsVisible = false;
            sizePicker.Items.Clear();
            valveSize = null;
            sizePicker.IsVisible = false;
            materialPicker.Items.Clear();
            bodyMaterial = null;
            materialPicker.IsVisible = false;
            sealMaterialPicker.SelectedItem = null;
            sealMaterial = null;
            sealMaterialPicker.IsVisible = false;
            ballOptionsPicker.Items.Clear();
            ballOptions = null;
            ballOptionsGrid.IsVisible = false;

            switch (valveType)
            {
                case 0: // 2-way
                    speedPicker.Items.Add("5 second");
                    speedPicker.Items.Add("1 second");
                    ballOptionsPicker.Items.Add("None");
                    ballOptionsPicker.Items.Add("Vented Ball");
                    ballOptionsPicker.Items.Add("Linear Flow Ball");
                    ballOptionsPicker.Items.Add("15° V-Cut Ball");
                    ballOptionsPicker.Items.Add("30° V-Cut Ball");
                    ballOptionsPicker.Items.Add("45° V-Cut Ball");
                    ballOptionsPicker.Items.Add("60° V-Cut Ball");
                    ballOptionsPicker.Items.Add("90° V-Cut Ball");
                    connectionPicker.Items.Add("NPT Threads");
                    connectionPicker.Items.Add("Metric Socket");
                    connectionPicker.Items.Add("IPS Socket");
                    connectionPicker.Items.Add("BSP Threads");
                    connectionPicker.Items.Add("ANSI 150 Flanges");
                    connectionPicker.Items.Add("Asahi Spigot");
                    connectionPicker.Items.Add("GF+ Spigot");
                    connectionPicker.Items.Add("SCH. 80 Spigot");
                    connectionPicker.Items.Add("Sanitary Tri-Clamp");
                    break;
                case 1: // 3-way
                    speedPicker.Items.Add("10 second");
                    speedPicker.Items.Add("2 second");
                    ballOptionsPicker.Items.Add("2-way Ball");
                    ballOptionsPicker.Items.Add("3-way Ball");
                    connectionPicker.Items.Add("NPT Threads");
                    connectionPicker.Items.Add("Metric Socket");
                    connectionPicker.Items.Add("IPS Socket");
                    connectionPicker.Items.Add("BSP Threads");
                    connectionPicker.Items.Add("ANSI 150 Flanges");
                    connectionPicker.Items.Add("SCH. 80 Spigot");
                    break;
            }
        }

        void AssignOLED(object sender, EventArgs args)
        {
            Picker oledPicker = (Picker)sender;
            oledDisplay = oledPicker.SelectedIndex;

            speedPicker.SelectedItem = null;
            actuatorSpeed = null;
            controlOptionsPicker.SelectedItem = null;
            controlOptions = null;
            switch (oledDisplay)
            {
                case 0: // Yes
                    speedPicker.IsVisible = true;
                    controlOptionsPicker.IsVisible = true;
                    break;
                case 1: // No
                    speedPicker.IsVisible = false;
                    controlOptionsPicker.IsVisible = false;
                    break;
            }
            connectionPicker.SelectedItem = null;
            connectionType = null;
            connectionPicker.IsVisible = true;
            sizePicker.Items.Clear();
            valveSize = null;
            sizePicker.IsVisible = false;
            materialPicker.Items.Clear();
            bodyMaterial = null;
            materialPicker.IsVisible = false;
            sealMaterialPicker.SelectedItem = null;
            sealMaterial = null;
            sealMaterialPicker.IsVisible = false;
            ballOptionsPicker.SelectedItem = null;
            ballOptions = null;
            ballOptionsGrid.IsVisible = false;
        }

        void AssignSpeed(object sender, EventArgs args)
        {
            Picker speedPicker = (Picker)sender;
            actuatorSpeed = speedPicker.SelectedIndex;
        }

        void AssignControlOptions(object sender, EventArgs args)
        {
            Picker controlOptionsPicker = (Picker)sender;
            controlOptions = controlOptionsPicker.SelectedIndex;
        }
            
        void AssignConnection(object sender, EventArgs args)
        {
            Picker connectionPicker = (Picker)sender;
            connectionType = connectionPicker.SelectedIndex;

            sizePicker.Items.Clear();
            valveSize = null;
            sizePicker.IsVisible = true;
            materialPicker.Items.Clear();
            bodyMaterial = null;
            materialPicker.IsVisible = true;
            sealMaterialPicker.SelectedItem = null;
            sealMaterial = null;
            sealMaterialPicker.IsVisible = true;
            ballOptionsPicker.SelectedItem = null;
            ballOptions = null;
            ballOptionsGrid.IsVisible = true;
            CalculateButton.IsVisible = true;
            switch (connectionType)
            {
                case 0: // NPT
                    sizePicker.Items.Add("3/8\"");
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/4\"");
                    sizePicker.Items.Add("1 1/2\"");
                    sizePicker.Items.Add("2\"");
                    materialPicker.Items.Add("PVC");
                    materialPicker.Items.Add("CPVC");
                    if (valveType == 0)
                    {
                        materialPicker.Items.Add("Polypro");
                        materialPicker.Items.Add("PVDF");
                        materialPicker.Items.Add("Red PVDF");
                    }                    
                    break;
                case 1: // Metric Socket
                    sizePicker.Items.Add("20mm");
                    sizePicker.Items.Add("25mm");
                    sizePicker.Items.Add("32mm");
                    sizePicker.Items.Add("40mm");
                    sizePicker.Items.Add("50mm");
                    sizePicker.Items.Add("63mm");
                    materialPicker.Items.Add("PVC");
                    materialPicker.Items.Add("CPVC");
                    if (valveType == 0)
                    {
                        materialPicker.Items.Add("Polypro");
                        materialPicker.Items.Add("PVDF");
                        materialPicker.Items.Add("Red PVDF");
                    }                    
                    break;
                case 2: // IPS Socket
                    sizePicker.Items.Add("3/8\"");
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/4\"");
                    sizePicker.Items.Add("1 1/2\"");
                    sizePicker.Items.Add("2\"");
                    materialPicker.Items.Add("PVC");
                    materialPicker.Items.Add("CPVC");
                    if (valveType == 0)
                    {
                        materialPicker.Items.Add("Polypro");
                        materialPicker.Items.Add("PVDF");
                        materialPicker.Items.Add("Red PVDF");
                    }                    
                    break;
                case 3: // BSP Threads
                    sizePicker.Items.Add("3/8\"");
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/4\"");
                    sizePicker.Items.Add("1 1/2\"");
                    sizePicker.Items.Add("2\"");
                    materialPicker.Items.Add("PVC");
                    materialPicker.Items.Add("CPVC");
                    if (valveType == 0)
                    {
                        materialPicker.Items.Add("Polypro");
                        materialPicker.Items.Add("PVDF");
                        materialPicker.Items.Add("Red PVDF");
                    }
                    break;
                case 4: // ANSI 150 Flanges
                    sizePicker.Items.Add("3/8\"");
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/4\"");
                    sizePicker.Items.Add("1 1/2\"");
                    sizePicker.Items.Add("2\"");
                    materialPicker.Items.Add("PVC");
                    materialPicker.Items.Add("CPVC");
                    if (valveType == 0)
                    {
                        materialPicker.Items.Add("Polypro");
                        materialPicker.Items.Add("PVDF");
                        materialPicker.Items.Add("Red PVDF");
                    }

                    break;
                case 5: // Asahi Metric Spigot
                    sizePicker.Items.Add("20mm");
                    sizePicker.Items.Add("25mm");
                    sizePicker.Items.Add("32mm");
                    sizePicker.Items.Add("40mm");
                    sizePicker.Items.Add("50mm");
                    sizePicker.Items.Add("63mm");
                    materialPicker.Items.Add("Polypro");
                    materialPicker.Items.Add("PVDF");
                    break;
                case 6: // GF+ Metric Spigot
                    sizePicker.Items.Add("20mm");
                    sizePicker.Items.Add("25mm");
                    sizePicker.Items.Add("32mm");
                    sizePicker.Items.Add("40mm");
                    sizePicker.Items.Add("50mm");
                    sizePicker.Items.Add("63mm");
                    materialPicker.Items.Add("Polypro");
                    materialPicker.Items.Add("PVDF");
                    break;
                case 7: // SCH. 80 Spigot
                    sizePicker.Items.Add("3/8\"");
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\"");
                    sizePicker.Items.Add("1\"");
                    sizePicker.Items.Add("1 1/4\"");
                    sizePicker.Items.Add("1 1/2\"");
                    sizePicker.Items.Add("2\"");
                    materialPicker.Items.Add("PVC");
                    materialPicker.Items.Add("CPVC");
                    if (valveType == 0)
                    {
                        materialPicker.Items.Add("Polypro");
                        materialPicker.Items.Add("PVDF");
                    }
                    break;
                case 8: // Sanitary Tri-Clamp
                    sizePicker.Items.Add("1/2\"");
                    sizePicker.Items.Add("3/4\" Mini");
                    sizePicker.Items.Add("1\" Maxi");
                    sizePicker.Items.Add("1\" Ladish");
                    sizePicker.Items.Add("1 1/2\"");
                    sizePicker.Items.Add("2\"");
                    materialPicker.Items.Add("Polypro");
                    materialPicker.Items.Add("PVDF");
                    break;
            }
        }

        void AssignPipeSize(object sender, EventArgs args)
        {
            Picker sizePicker = (Picker)sender;
            valveSize = sizePicker.SelectedIndex;
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

        void AssignBallOptions(object sender, EventArgs args)
        {
            Picker ballOptionsPicker = (Picker)sender;
            ballOptions = ballOptionsPicker.SelectedIndex;
        }
        // END: Picker Methods

        async void DisplayInfo(object sender, EventArgs args)
        {
            await DisplayAlert("Ball Options", "Most applications use a “Standard 2-way” or full flow ball, which is the default option.  “Vented ball” refers to a small hole drilled for sodium hypochlorite and other applications prone to outgassing.   When turned to the closed position, the hole allows any liquid or gas in the ball to flow freely in and out of the ball.  This eliminates the possibility of catastrophic trapped gas explosions in the ball.  “Linear Flow” is a specially-cut opening profile that eliminates the sudden surge of flow common when opening standard full flow balls.  Flow increases at a linear rate as the ball is opened, and decreases at a linear rate as the ball is closed.  This is commonly used with modulating control to provide precise flow rates.  “V-Cut” offers similar control; these are custom angle cut profiles to provide very specific flow rates.", "Okay");
        }

        async void calculateCheck(object sender, EventArgs args)
        {
            try { __valveSize = sizePicker.Items[sizePicker.SelectedIndex]; } catch { }
            try { __bodyMaterial = materialPicker.Items[materialPicker.SelectedIndex]; } catch { }
            try { __ballOptions = ballOptionsPicker.Items[ballOptionsPicker.SelectedIndex]; } catch { }
            try { __actuatorSpeed = speedPicker.Items[speedPicker.SelectedIndex]; } catch { }
            try { __connectionType = connectionPicker.Items[connectionPicker.SelectedIndex]; } catch { }
            try { __controlOptions = controlOptionsPicker.Items[controlOptionsPicker.SelectedIndex]; } catch { }
            switch (oledDisplay)
            {
                case 0: // Yes
                    if (valveType != null && oledDisplay != null && actuatorSpeed != null && controlOptions != null && connectionType != null && valveSize != null && bodyMaterial != null && sealMaterial != null && ballOptions != null)
                    {
                        await Navigation.PushAsync(new Cafe2(valveType, oledDisplay, actuatorSpeed, __actuatorSpeed, controlOptions, __controlOptions, __connectionType, __valveSize, __bodyMaterial, sealMaterial, __ballOptions));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a selection", "Okay");
                    }
                    break;
                case 1: // No
                    if (valveType != null && oledDisplay != null && connectionType != null && valveSize != null && bodyMaterial != null && sealMaterial != null && ballOptions != null)
                    {
                        await Navigation.PushAsync(new Cafe2(valveType, oledDisplay, actuatorSpeed, __actuatorSpeed, controlOptions, __controlOptions, __connectionType, __valveSize, __bodyMaterial, sealMaterial, __ballOptions));
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