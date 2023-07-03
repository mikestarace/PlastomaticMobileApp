using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        int? valveApplication;
        int? valveBodyMaterial;
        int? valveSealMaterial;
        int? valveSize;
        int? _desiredSetPressure;
        int? maxInletPressure;

        void AssignApplication(object sender, EventArgs args)
        {
            Picker applicationPicker = (Picker)sender;
            valveApplication = applicationPicker.SelectedIndex;
            // Assigns the application chosen by the user in the dropdown menu. Index 0 is standard pressure regulator, etc...
        }

        void AssignSetPressure(object sender, EventArgs args)
        {
            Picker DesiredSetPressurePicker = (Picker)sender;
            _desiredSetPressure = DesiredSetPressurePicker.SelectedIndex;
            // Assigns the desired set pressure chosen by the user in the dropdown menu. Index 0 is 05 PSI, index 1 is 10 PSI, etc...
        }

        void AssignMaterial(object sender, EventArgs args)
        {
            Picker materialPicker = (Picker)sender;
            valveBodyMaterial = materialPicker.SelectedIndex;
            // Assigns the body material chosen by the user in the dropdown menu. Index 0 is PVC, etc...
        }

        void AssignSealMaterial(object sender, EventArgs args)
        {
            Picker sealMaterialPicker = (Picker)sender;
            valveSealMaterial = sealMaterialPicker.SelectedIndex;
            // Assigns the seal material chosen by the user in the dropdown menu. Index 0 is Viton, etc...
        }

        void AssignPipeSize(object sender, EventArgs args)
        {
            Picker sizePicker = (Picker)sender;
            valveSize = sizePicker.SelectedIndex;
            // Assigns the size chosen by the user in the dropdown menu. Index 0 is 1/2", Index 1 is 3/4", etc...
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

            }

        }

        void AssignMaxInlet(object sender, EventArgs args)
        {
            Picker maxInletPicker = (Picker)sender;
            maxInletPressure = maxInletPicker.SelectedIndex;

        }


        int _requiredFlowRate;

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
            

            if (valveApplication == null)
            {
                await DisplayAlert("Error", "You must select the valve application", "Okay");
            }
            else if (valveSize == null)
            {
                await DisplayAlert("Error", "You must select the pipe size", "Okay");
            }
            else if (maxInletPressure == null)
            {
                await DisplayAlert("Error", "You must select the maximum system inlet pressure", "Okay");
            }
            else if (_desiredSetPressure == null)
            {
                await DisplayAlert("Error", "You must select the desired set pressure", "Okay");
            }
            else if (valveBodyMaterial == null)
            {
                await DisplayAlert("Error", "You must select the valve body material", "Okay");
            }
            else if (valveSealMaterial == null)
            {
                await DisplayAlert("Error", "You must select the valve seal material", "Okay");
            }


            else
            {
                await Navigation.PushAsync(new PressureRegulator2(maxInletPressure, _desiredSetPressure, _requiredFlowRate, valveApplication, valveBodyMaterial, valveSealMaterial, valveSize));
            }
        }
    }
}