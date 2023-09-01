using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PulsationDampener1 : ContentPage
    {
        public PulsationDampener1()
        {
            InitializeComponent();
            BindingContext = this;
        }

        int? pipeDiameter;
        int? pipeLength;
        int? linePressure;
        int? bodyMaterial;
        int? sealMaterial;
        // Declaring variables for selected indeces and required flow rate

        string _pipeDiameter;
        string _pipeLength;
        string _linePressure;
        string _bodyMaterial;
        string _sealMaterial;
        // Declaring variables for getting picker texts

        // START: Picker Methods
        void AssignPipeDiameter(object sender, EventArgs args)
        {
            Picker diameterPicker = (Picker)sender;
            pipeDiameter = diameterPicker.SelectedIndex;
        }
        void AssignPipeLength(object sender, EventArgs args)
        {
            Picker lengthPicker = (Picker)sender;
            pipeLength = lengthPicker.SelectedIndex;
        }
        void AssignPressure(object sender, EventArgs args)
        {
            Picker pressurePicker = (Picker)sender;
            linePressure = pressurePicker.SelectedIndex;
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
        // END: Picker Methods

        async void calculateCheck(object sender, EventArgs args)
        {
            try { _pipeDiameter = diameterPicker.Items[diameterPicker.SelectedIndex]; } catch { }
            try { _pipeLength = lengthPicker.Items[lengthPicker.SelectedIndex]; } catch { }
            try { _linePressure = pressurePicker.Items[pressurePicker.SelectedIndex]; } catch { }
            try { _bodyMaterial = materialPicker.Items[materialPicker.SelectedIndex]; } catch { }
            try { _sealMaterial = sealMaterialPicker.Items[sealMaterialPicker.SelectedIndex]; } catch { }

            if (pipeDiameter != null && pipeLength != null && linePressure != null && bodyMaterial != null && sealMaterial != null)
            {
                await Navigation.PushAsync(new PulsationDampener2(_pipeDiameter, _pipeLength, _linePressure, _bodyMaterial, _sealMaterial, pipeDiameter, pipeLength, linePressure, bodyMaterial, sealMaterial));
            }
            else
            {
                await DisplayAlert("Error", "Please make a selection", "Okay");
            }
        }
    }
}