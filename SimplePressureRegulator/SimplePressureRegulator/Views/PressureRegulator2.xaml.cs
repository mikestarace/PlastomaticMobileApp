using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PressureRegulator2 : ContentPage
    {

        private string oneFourthCode;
        private string oneFourthCode2;
        private string oneHalfCode;
        private string threeFourthCode;
        private string oneWholeCode;
        private string oneOneHalfCode;
        private string twoWholeCode;
        private string threeWholeCode;

        async void OneFourthLink(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://plastomatic.com/products/product/" + oneFourthCode);
        }
        async void OneFourthLink2(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://plastomatic.com/products/product/" + oneFourthCode2);
        }
        async void OneHalfLink(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://plastomatic.com/products/product/" + oneHalfCode);
        }
        async void ThreeFourthLink(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://plastomatic.com/products/product/" + threeFourthCode);
        }
        async void OneWholeLink(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://plastomatic.com/products/product/" + oneWholeCode);
        }
        async void OneOneHalfLink(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://plastomatic.com/products/product/" + oneOneHalfCode);
        }
        async void TwoWholeLink(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://plastomatic.com/products/product/" + twoWholeCode);
        }
        async void ThreeWholeLink(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://plastomatic.com/products/product/" + threeWholeCode);
        }


        public PressureRegulator2(int? maxInletPressure, int? _desiredSetPressure, int _requiredFlowRate, int? valveApplication, int? valveBodyMaterial, int? valveSealMaterial, int? connectionType, int? valveSize)
        {
            InitializeComponent();
            RequiredFlowRateLabel.Text = _requiredFlowRate.ToString() + " GPM";
            double desiredSetPressure = 0;
            switch (_desiredSetPressure)
            {
                case 0: // 05 PSI
                    DesiredSetPressureLabel.Text = "05 PSI";
                    desiredSetPressure = 5.0;
                    break;
                case 1: // 10 PSI
                    DesiredSetPressureLabel.Text = "10 PSI";
                    desiredSetPressure = 10.0;
                    break;
                case 2: // 15 PSI
                    DesiredSetPressureLabel.Text = "15 PSI";
                    desiredSetPressure = 15.0;
                    break;
                case 3: // 20 PSI
                    DesiredSetPressureLabel.Text = "20 PSI";
                    desiredSetPressure = 20.0;
                    break;
                case 4: // 25 PSI
                    DesiredSetPressureLabel.Text = "25 PSI";
                    desiredSetPressure = 25.0;
                    break;
                case 5: // 30 PSI
                    DesiredSetPressureLabel.Text = "30";
                    desiredSetPressure = 30.0;
                    break;
                case 6: // 40 PSI
                    DesiredSetPressureLabel.Text = "40";
                    desiredSetPressure = 40.0;
                    break;
                case 7: // 50 PSI
                    DesiredSetPressureLabel.Text = "50";
                    desiredSetPressure = 50.0;
                    break;
            }
            switch (valveSize)
            {
                case 0: // 1/4"
                    PipeSizeLabel.Text = "1/4\"";
                    if (maxInletPressure == 0)
                    {
                        MaxSystemInletLabel.Text = "15 PSI";
                    }
                    else
                    {
                        MaxSystemInletLabel.Text = "30 & Up";
                    }
                    break;
                case 1: // 1/2"
                    if (valveApplication == 0)
                    {
                        PipeSizeLabel.Text = "1/2\"";
                    }
                    else
                    {
                        PipeSizeLabel.Text = "20 mm";
                    }
                    if (maxInletPressure == 0)
                    {
                        MaxSystemInletLabel.Text = "15 PSI";
                    }
                    else
                    {
                        MaxSystemInletLabel.Text = "30 & Up";
                    }
                    break;
                case 2: // 3/4"
                    if (valveApplication == 0)
                    {
                        PipeSizeLabel.Text = "3/4\"";
                    }
                    else
                    {
                        PipeSizeLabel.Text = "25 mm";
                    }
                    if (maxInletPressure == 0)
                    {
                        MaxSystemInletLabel.Text = "10 PSI";
                    }
                    else
                    {
                        MaxSystemInletLabel.Text = "25 & Up";
                    }
                    break;
                case 3: // 1"
                    if (valveApplication == 0)
                    {
                        PipeSizeLabel.Text = "1\"";
                    }
                    else
                    {
                        PipeSizeLabel.Text = "32 mm";
                    }
                    if (maxInletPressure == 0)
                    {
                        MaxSystemInletLabel.Text = "10 PSI";
                    }
                    else
                    {
                        MaxSystemInletLabel.Text = "25 & Up";
                    }
                    break;
                case 4: // 1 1/2"
                    if (valveApplication == 0)
                    {
                        PipeSizeLabel.Text = "1 1/2\"";
                    }
                    else
                    {
                        PipeSizeLabel.Text = "50 mm";
                    }
                    if (maxInletPressure == 0)
                    {
                        MaxSystemInletLabel.Text = "10 PSI";
                    }
                    else
                    {
                        MaxSystemInletLabel.Text = "25 & Up";
                    }
                    break;
                case 5: // 2"
                    if (valveApplication == 0)
                    {
                        PipeSizeLabel.Text = "2\"";
                    }
                    else
                    {
                        PipeSizeLabel.Text = "63 mm";
                    }
                    if (maxInletPressure == 0)
                    {
                        MaxSystemInletLabel.Text = "10 PSI";
                    }
                    else
                    {
                        MaxSystemInletLabel.Text = "25 & Up";
                    }
                    break;
                case 6: // 3"
                    PipeSizeLabel.Text = "3\"";
                    if (maxInletPressure == 0)
                    {
                        MaxSystemInletLabel.Text = "10 PSI";
                    }
                    else
                    {
                        MaxSystemInletLabel.Text = "25 & Up";
                    }
                    break;
            }
            // CREATING THE 3D ARRAY
            double[,] arrayGPM = new double[14, 8];
            arrayGPM[0, 0]
                = 1.0;
            arrayGPM[1, 0]
                = 1.0;
            arrayGPM[2, 0]
                = 2.0;
            arrayGPM[3, 0]
                = 3.0;
            arrayGPM[4, 0]
                = 8.0;
            arrayGPM[5, 0]
                = 8.0;
            arrayGPM[6, 0]
                = 11.0;
            arrayGPM[7, 0]
                = 11.0;
            arrayGPM[8, 0]
                = 16.0;
            arrayGPM[9, 0]
                = 16.0;
            arrayGPM[10, 0]
                = 20.0;
            arrayGPM[11, 0]
                = 20.0;
            arrayGPM[12, 0]
                = 50.0;
            arrayGPM[13, 0]
                = 50.0;
            arrayGPM[0, 1]
                = 3.0;
            arrayGPM[1, 1]
                = 3.0;
            arrayGPM[2, 1]
                = 6.0;
            arrayGPM[3, 1]
                = 7.0;
            arrayGPM[4, 1]
                = 14.0;
            arrayGPM[5, 1]
                = 18.0;
            arrayGPM[6, 1]
                = 20.0;
            arrayGPM[7, 1]
                = 25.0;
            arrayGPM[8, 1]
                = 28.0;
            arrayGPM[9, 1]
                = 36.0;
            arrayGPM[10, 1]
                = 30.0;
            arrayGPM[11, 1]
                = 50.0;
            arrayGPM[12, 1]
                = 65.0;
            arrayGPM[13, 1]
                = 100.0;
            arrayGPM[0, 2]
                = 3.5;
            arrayGPM[1, 2]
                = 4.0;
            arrayGPM[2, 2]
                = 7.0;
            arrayGPM[3, 2]
                = 9.0;
            arrayGPM[4, 2]
                = 18.0;
            arrayGPM[5, 2]
                = 29.0;
            arrayGPM[6, 2]
                = 25.0;
            arrayGPM[7, 2]
                = 40.0;
            arrayGPM[8, 2]
                = 36.0;
            arrayGPM[9, 2]
                = 58.0;
            arrayGPM[10, 2]
                = 40.0;
            arrayGPM[11, 2]
                = 80.0;
            arrayGPM[12, 2]
                = 80.0;
            arrayGPM[13, 2]
                = 160.0;
            arrayGPM[0, 3]
                = 3.5;
            arrayGPM[1, 3]
                = 4.5;
            arrayGPM[2, 3]
                = 7.0;
            arrayGPM[3, 3]
                = 10.0;
            arrayGPM[4, 3]
                = 18.0;
            arrayGPM[5, 3]
                = 35.0;
            arrayGPM[6, 3]
                = 25.0;
            arrayGPM[7, 3]
                = 50.0;
            arrayGPM[8, 3]
                = 36.0;
            arrayGPM[9, 3]
                = 70.0;
            arrayGPM[10, 3]
                = 50.0;
            arrayGPM[11, 3]
                = 100.0;
            arrayGPM[12, 3]
                = 100.0;
            arrayGPM[13, 3]
                = 200.0;
            arrayGPM[0, 4]
                = 3.5;
            arrayGPM[1, 4]
                = 5.0;
            arrayGPM[2, 4]
                = 7.0;
            arrayGPM[3, 4]
                = 10.0;
            arrayGPM[4, 4]
                = 18.0;
            arrayGPM[5, 4]
                = 35.0;
            arrayGPM[6, 4]
                = 25.0;
            arrayGPM[7, 4]
                = 50.0;
            arrayGPM[8, 4]
                = 36.0;
            arrayGPM[9, 4]
                = 70.0;
            arrayGPM[10, 4]
                = 50.0;
            arrayGPM[11, 4]
                = 100.0;
            arrayGPM[12, 4]
                = 100.0;
            arrayGPM[13, 4]
                = 200.0;
            arrayGPM[0, 5]
                = 3.5;
            arrayGPM[1, 5]
                = 5.0;
            arrayGPM[2, 5]
                = 7.0;
            arrayGPM[3, 5]
                = 10.0;
            arrayGPM[4, 5]
                = 18.0;
            arrayGPM[5, 5]
                = 35.0;
            arrayGPM[6, 5]
                = 25.0;
            arrayGPM[7, 5]
                = 50.0;
            arrayGPM[8, 5]
                = 36.0;
            arrayGPM[9, 5]
                = 70.0;
            arrayGPM[10, 5]
                = 50.0;
            arrayGPM[11, 5]
                = 100.0;
            arrayGPM[12, 5]
                = 100.0;
            arrayGPM[13, 5]
                = 200.0;
            arrayGPM[0, 6]
                = 3.5;
            arrayGPM[1, 6]
                = 5.0;
            arrayGPM[2, 6]
                = 7.0;
            arrayGPM[3, 6]
                = 10.0;
            arrayGPM[4, 6]
                = 18.0;
            arrayGPM[5, 6]
                = 35.0;
            arrayGPM[6, 6]
                = 25.0;
            arrayGPM[7, 6]
                = 50.0;
            arrayGPM[8, 6]
                = 36.0;
            arrayGPM[9, 6]
                = 70.0;
            arrayGPM[10, 6]
                = 50.0;
            arrayGPM[11, 6]
                = 100.0;
            arrayGPM[12, 6]
                = 100.0;
            arrayGPM[13, 6]
                = 200.0;
            arrayGPM[0, 7]
                = 3.5;
            arrayGPM[1, 7]
                = 5.0;
            arrayGPM[2, 7]
                = 7.0;
            arrayGPM[3, 7]
                = 10.0;
            arrayGPM[4, 7]
                = 18.0;
            arrayGPM[5, 7]
                = 35.0;
            arrayGPM[6, 7]
                = 25.0;
            arrayGPM[7, 7]
                = 50.0;
            arrayGPM[8, 7]
                = 36.0;
            arrayGPM[9, 7]
                = 70.0;
            arrayGPM[10, 7]
                = 50.0;
            arrayGPM[11, 7]
                = 100.0;
            arrayGPM[12, 7]
                = 100.0;
            arrayGPM[13, 7]
                = 200.0;

            // DETERMINING X VALUE OF ARRAY
            int? arrayXvalue = null;
            if (valveSize == 0 && maxInletPressure == 0)
            {
                arrayXvalue = 0;
            } else if (valveSize == 0 && maxInletPressure == 1)
            {
                arrayXvalue = 1;
            }
            else if (valveSize == 1 && maxInletPressure == 0)
            {
                arrayXvalue = 2;
            }
            else if (valveSize == 1 && maxInletPressure == 1)
            {
                arrayXvalue = 3;
            }
            else if (valveSize == 2 && maxInletPressure == 0)
            {
                arrayXvalue = 4;
            }
            else if (valveSize == 2 && maxInletPressure == 1)
            {
                arrayXvalue = 5;
            }
            else if (valveSize == 3 && maxInletPressure == 0)
            {
                arrayXvalue = 6;
            }
            else if (valveSize == 3 && maxInletPressure == 1)
            {
                arrayXvalue = 7;
            }
            else if (valveSize == 4 && maxInletPressure == 0)
            {
                arrayXvalue = 8;
            }
            else if (valveSize == 4 && maxInletPressure == 1)
            {
                arrayXvalue = 9;
            }
            else if (valveSize == 5 && maxInletPressure == 0)
            {
                arrayXvalue = 10;
            }
            else if (valveSize == 5 && maxInletPressure == 1)
            {
                arrayXvalue = 11;
            }
            else if (valveSize == 6 && maxInletPressure == 0)
            {
                arrayXvalue = 12;
            }
            else if (valveSize == 6 && maxInletPressure == 1)
            {
                arrayXvalue = 13;
            }


            // DETERMINING ARRAY Y VALUE
            int arrayYvalue = _desiredSetPressure.Value;

            // GETTING THE MAX FLOW RATE AND ATTACHING IT TO THE LABEL
            double maxFlowRate = arrayGPM[arrayXvalue.Value, arrayYvalue];
            if (maxFlowRate < _requiredFlowRate)
            {
                GPMLabel.Text = "Max flow rate: " + maxFlowRate.ToString() + " GPM (WARNING: your requested flow rate exceeds the max flow rate)";
                GPMLabel.TextColor = Color.Red;
            }
            if (maxFlowRate >= _requiredFlowRate)
            {
                GPMLabel.Text = "Max flow rate: " + maxFlowRate.ToString() + " GPM";
                GPMLabel.TextColor = Color.Green;
            }



            // PRESSURE DROP ARRAYS

            double[,] OneFourthArray = new double[2, 5];
            OneFourthArray[0, 0] // Flow
                = 1.0;
            OneFourthArray[1, 0] // Pressure Drop
                = 4.0;
            OneFourthArray[0, 1] // Flow
                = 3.0;
            OneFourthArray[1, 1] // Pressure Drop
                = 7.0;
            OneFourthArray[0, 2] // Flow
                = 4.0;
            OneFourthArray[1, 2] // Pressure Drop
                = 12.0;
            OneFourthArray[0, 3] // Flow
                = 4.5;
            OneFourthArray[1, 3] // Pressure Drop
                = 16.0;
            OneFourthArray[0, 4] // Flow
                = 5.0;
            OneFourthArray[1, 4] // Pressure Drop
                = 18.0;

            double[,] OneHalfArray = new double[2, 5];
            OneHalfArray[0, 0] // Flow
                = 1.5;
            OneHalfArray[1, 0] // Pressure Drop
                = 4.0;
            OneHalfArray[0, 1] // Flow
                = 2.5;
            OneHalfArray[1, 1] // Pressure Drop
                = 5.0;
            OneHalfArray[0, 2] // Flow
                = 6.0;
            OneHalfArray[1, 2] // Pressure Drop
                = 6.5;
            OneHalfArray[0, 3] // Flow
                = 7.0;
            OneHalfArray[1, 3] // Pressure Drop
                = 9.0;
            OneHalfArray[0, 4] // Flow
                = 10.0;
            OneHalfArray[1, 4] // Pressure Drop
                = 13.0;

            double[,] ThreeFourthArray = new double[2, 5];
            ThreeFourthArray[0, 0] // Flow
                = 8.0;
            ThreeFourthArray[1, 0] // Pressure Drop
                = 4.0;
            ThreeFourthArray[0, 1] // Flow
                = 14.0;
            ThreeFourthArray[1, 1] // Pressure Drop
                = 6.5;
            ThreeFourthArray[0, 2] // Flow
                = 25.0;
            ThreeFourthArray[1, 2] // Pressure Drop
                = 10.0;
            ThreeFourthArray[0, 3] // Flow
                = 29.0;
            ThreeFourthArray[1, 3] // Pressure Drop
                = 12.0;
            ThreeFourthArray[0, 4] // Flow
                = 35.0;
            ThreeFourthArray[1, 4] // Pressure Drop
                = 14.0;

            double[,] OneWholeArray = new double[2, 5];
            OneWholeArray[0, 0] // Flow
                = 11.0;
            OneWholeArray[1, 0] // Pressure Drop
                = 4.5;
            OneWholeArray[0, 1] // Flow
                = 20.0;
            OneWholeArray[1, 1] // Pressure Drop
                = 7.0;
            OneWholeArray[0, 2] // Flow
                = 25.0;
            OneWholeArray[1, 2] // Pressure Drop
                = 11.0;
            OneWholeArray[0, 3] // Flow
                = 40.0;
            OneWholeArray[1, 3] // Pressure Drop
                = 13.0;
            OneWholeArray[0, 4] // Flow
                = 50.0;
            OneWholeArray[1, 4] // Pressure Drop
                = 15.0;

            double[,] OneOneHalfArray = new double[2, 5];
            OneOneHalfArray[0, 0] // Flow
                = 16.0;
            OneOneHalfArray[1, 0] // Pressure Drop
                = 5.0;
            OneOneHalfArray[0, 1] // Flow
                = 28.0;
            OneOneHalfArray[1, 1] // Pressure Drop
                = 7.5;
            OneOneHalfArray[0, 2] // Flow
                = 36.0;
            OneOneHalfArray[1, 2] // Pressure Drop
                = 12.0;
            OneOneHalfArray[0, 3] // Flow
                = 58.0;
            OneOneHalfArray[1, 3] // Pressure Drop
                = 14.0;
            OneOneHalfArray[0, 4] // Flow
                = 70.0;
            OneOneHalfArray[1, 4] // Pressure Drop
                = 16.0;

            double[,] TwoWholeArray = new double[2, 5];
            TwoWholeArray[0, 0] // Flow
                = 20.0;
            TwoWholeArray[1, 0] // Pressure Drop
                = 5.0;
            TwoWholeArray[0, 1] // Flow
                = 40.0;
            TwoWholeArray[1, 1] // Pressure Drop
                = 8.0;
            TwoWholeArray[0, 2] // Flow
                = 60.0;
            TwoWholeArray[1, 2] // Pressure Drop
                = 12.0;
            TwoWholeArray[0, 3] // Flow
                = 80.0;
            TwoWholeArray[1, 3] // Pressure Drop
                = 14.0;
            TwoWholeArray[0, 4] // Flow
                = 100.0;
            TwoWholeArray[1, 4] // Pressure Drop
                = 16.0;

            double[,] ThreeWholeArray = new double[2, 5];
            ThreeWholeArray[0, 0] // Flow
                = 50.0;
            ThreeWholeArray[1, 0] // Pressure Drop
                = 6.0;
            ThreeWholeArray[0, 1] // Flow
                = 100.0;
            ThreeWholeArray[1, 1] // Pressure Drop
                = 9.0;
            ThreeWholeArray[0, 2] // Flow
                = 130.0;
            ThreeWholeArray[1, 2] // Pressure Drop
                = 11.0;
            ThreeWholeArray[0, 3] // Flow
                = 160.0;
            ThreeWholeArray[1, 3] // Pressure Drop
                = 13.0;
            ThreeWholeArray[0, 4] // Flow
                = 200.0;
            ThreeWholeArray[1, 4] // Pressure Drop
                = 16.0;

            switch (valveApplication)
            {
                case 0: // High Performance Pressure Regulator
                    ValveApplicationLabel.Text = "High Performance Pressure Regulator";
                    SealMaterialLabel.IsVisible = true;
                    SealMaterialLabel1.IsVisible = true;
                    CalculatePRHM(valveBodyMaterial, valveSealMaterial, _requiredFlowRate, OneFourthArray, OneHalfArray, ThreeFourthArray, OneWholeArray, OneOneHalfArray, TwoWholeArray, ThreeWholeArray);
                    break;
                case 1: // Ultra-Pure Elastomer-Free
                    ValveApplicationLabel.Text = "Ultra-Pure Elastomer-Free";
                    MaterialLabel.Text = "PVDF";
                    ConnectionTypeLabel.IsVisible = true;
                    ConnectionTypeLabel1.IsVisible = true;
                    CalculateUPR(connectionType, _requiredFlowRate, OneFourthArray, OneHalfArray, ThreeFourthArray, OneWholeArray, OneOneHalfArray, TwoWholeArray, ThreeWholeArray);
                    break;
            }

        } // End of Main Method


        void CalculatePRHM(int? valveBodyMaterial, int? valveSealMaterial, int _requiredFlowRate, double[,] OneFourthArray, double[,] OneHalfArray, double[,] ThreeFourthArray, double[,] OneWholeArray, double[,] OneOneHalfArray, double[,] TwoWholeArray, double[,] ThreeWholeArray)
        {
            string sealMaterialCode = "";
            string bodyMaterialCode = "";
            string ptfeChecker = "";
            string ptfeChecker2 = "";
            string ptfeChecker3 = "";

            // These will help to get the correct valve key based on body material and seal material.
            // These will ONLY work for PRHM valves
            switch (valveBodyMaterial)
            {
                case 0: // PVC
                    MaterialLabel.Text = "PVC";
                    bodyMaterialCode = "PV";
                    ptfeChecker = "HM";
                    ptfeChecker2 = "HM";
                    ptfeChecker3 = "H";
                    break;
                case 1: // CPVC
                    MaterialLabel.Text = "CPVC";
                    bodyMaterialCode = "CP";
                    ptfeChecker = "HM";
                    ptfeChecker2 = "HM";
                    break;
                case 2: // Polypro
                    MaterialLabel.Text = "Polypro";
                    bodyMaterialCode = "PP";
                    ptfeChecker = "HM";
                    ptfeChecker2 = "HM";
                    break;
                case 3: // PTFE
                    MaterialLabel.Text = "PTFE";
                    bodyMaterialCode = "TF";
                    ptfeChecker = "H";
                    break;
                case 4: // PVDF
                    MaterialLabel.Text = "PVDF";
                    bodyMaterialCode = "PF";
                    ptfeChecker = "HM";
                    ptfeChecker2 = "HM";
                    ptfeChecker3 = "H";
                    break;
            }
            switch (valveSealMaterial)
            {
                case 0: // Viton
                    SealMaterialLabel.Text = "Viton";
                    sealMaterialCode = "V";
                    break;
                case 1: // EPDM
                    SealMaterialLabel.Text = "EPDM";
                    sealMaterialCode = "EP";
                    break;
            }

            // This code will display the valve key, and set it as a variable for the "View on Website" buttons to use
            // 1/4" Valves
            if (_requiredFlowRate >= OneFourthArray[0, 0] && _requiredFlowRate <= OneFourthArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == OneFourthArray[0, i])
                    {
                        OneFourthPlaceholder.Text = "1/4\" valve, pressure drop at " + _requiredFlowRate + " GPM: " + OneFourthArray[1, i] + " PSI";
                        OneFourthPlaceholder.IsVisible = true;
                        OneFourthPlaceholder2.Text = "Valve model number: PRH025" + sealMaterialCode + "-" + bodyMaterialCode;
                        OneFourthPlaceholder2.IsVisible = true;
                        OneFourthButton.IsVisible = true;
                        oneFourthCode = "PRH025" + sealMaterialCode + "-" + bodyMaterialCode;
                        break;
                    }
                    else if (_requiredFlowRate < OneFourthArray[0, i])
                    {
                        OneFourthPlaceholder.Text = "1/4\" valve, pressure drop at " + _requiredFlowRate + " GPM: between " + OneFourthArray[1, i - 1] + " and " + OneFourthArray[1, i] + " PSI";
                        OneFourthPlaceholder.IsVisible = true;
                        OneFourthPlaceholder2.Text = "Valve model number: PRH025" + sealMaterialCode + "-" + bodyMaterialCode;
                        OneFourthPlaceholder2.IsVisible = true;
                        OneFourthButton.IsVisible = true;
                        oneFourthCode = "PRH025" + sealMaterialCode + "-" + bodyMaterialCode;
                        break;
                    }
                }
            }
            // 1/2" Valves
            if (_requiredFlowRate >= OneHalfArray[0, 0] && _requiredFlowRate <= OneHalfArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == OneHalfArray[0, i])
                    {
                        OneHalfPlaceholder.Text = "1/2\" valve, pressure drop at " + _requiredFlowRate + " GPM: " + OneHalfArray[1, i] + " PSI";
                        OneHalfPlaceholder.IsVisible = true;
                        OneHalfPlaceholder2.Text = "Valve model number: PR" + ptfeChecker + "050" + sealMaterialCode + "-" + bodyMaterialCode;
                        OneHalfPlaceholder2.IsVisible = true;
                        OneHalfButton.IsVisible = true;
                        oneHalfCode = "PR" + ptfeChecker + "050" + sealMaterialCode + "-" + bodyMaterialCode;
                        break;
                    }
                    else if (_requiredFlowRate < OneHalfArray[0, i])
                    {
                        OneHalfPlaceholder.Text = "1/2\" valve, pressure drop at " + _requiredFlowRate + " GPM: between " + OneHalfArray[1, i - 1] + " and " + OneHalfArray[1, i] + " PSI";
                        OneHalfPlaceholder.IsVisible = true;
                        OneHalfPlaceholder2.Text = "Valve model number: PR" + ptfeChecker + "050" + sealMaterialCode + "-" + bodyMaterialCode;
                        OneHalfPlaceholder2.IsVisible = true;
                        OneHalfButton.IsVisible = true;
                        oneHalfCode = "PR" + ptfeChecker + "050" + sealMaterialCode + "-" + bodyMaterialCode;
                        break;
                    }
                }
            }
            // 3/4" Valves
            if (_requiredFlowRate >= ThreeFourthArray[0, 0] && _requiredFlowRate <= ThreeFourthArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == ThreeFourthArray[0, i])
                    {
                        ThreeFourthPlaceholder.Text = "3/4\" valve, pressure drop at " + _requiredFlowRate + " GPM: " + ThreeFourthArray[1, i] + " PSI";
                        ThreeFourthPlaceholder.IsVisible = true;
                        ThreeFourthPlaceholder2.Text = "Valve model number: PR" + ptfeChecker + "075" + sealMaterialCode + "-" + bodyMaterialCode;
                        ThreeFourthPlaceholder2.IsVisible = true;
                        ThreeFourthButton.IsVisible = true;
                        threeFourthCode = "PR" + ptfeChecker + "075" + sealMaterialCode + "-" + bodyMaterialCode;
                        break;
                    }
                    else if (_requiredFlowRate < ThreeFourthArray[0, i])
                    {
                        ThreeFourthPlaceholder.Text = "3/4\" valve, pressure drop at " + _requiredFlowRate + " GPM: between " + ThreeFourthArray[1, i - 1] + " and " + ThreeFourthArray[1, i] + " PSI";
                        ThreeFourthPlaceholder.IsVisible = true;
                        ThreeFourthPlaceholder2.Text = "Valve model number: PR" + ptfeChecker + "075" + sealMaterialCode + "-" + bodyMaterialCode;
                        ThreeFourthPlaceholder2.IsVisible = true;
                        ThreeFourthButton.IsVisible = true;
                        threeFourthCode = "PR" + ptfeChecker + "075" + sealMaterialCode + "-" + bodyMaterialCode;
                        break;
                    }
                }
            }
            // 1" Valves
            if (_requiredFlowRate >= OneWholeArray[0, 0] && _requiredFlowRate <= OneWholeArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == OneWholeArray[0, i])
                    {
                        OneWholePlaceholder.Text = "1\" valve, pressure drop at " + _requiredFlowRate + " GPM: " + OneWholeArray[1, i] + " PSI";
                        OneWholePlaceholder.IsVisible = true;
                        OneWholePlaceholder2.Text = "Valve model number: PR" + ptfeChecker + "100" + sealMaterialCode + "-" + bodyMaterialCode;
                        OneWholePlaceholder2.IsVisible = true;
                        OneWholeButton.IsVisible = true;
                        oneWholeCode = "PR" + ptfeChecker + "100" + sealMaterialCode + "-" + bodyMaterialCode;
                        break;
                    }
                    else if (_requiredFlowRate < OneWholeArray[0, i])
                    {
                        OneWholePlaceholder.Text = "1\" valve, pressure drop at " + _requiredFlowRate + " GPM: between " + OneWholeArray[1, i - 1] + " and " + OneWholeArray[1, i] + " PSI";
                        OneWholePlaceholder.IsVisible = true;
                        OneWholePlaceholder2.Text = "Valve model number: PR" + ptfeChecker + "100" + sealMaterialCode + "-" + bodyMaterialCode;
                        OneWholePlaceholder2.IsVisible = true;
                        OneWholeButton.IsVisible = true;
                        oneWholeCode = "PR" + ptfeChecker + "100" + sealMaterialCode + "-" + bodyMaterialCode;
                        break;
                    }
                }
            }
            //1 1/2" Valves
            if (_requiredFlowRate >= OneOneHalfArray[0, 0] && _requiredFlowRate <= OneOneHalfArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == OneOneHalfArray[0, i])
                    {
                        OneOneHalfPlaceholder.Text = "1 1/2\" valve, pressure drop at " + _requiredFlowRate + " GPM: " + OneOneHalfArray[1, i] + " PSI";
                        OneOneHalfPlaceholder.IsVisible = true;
                        OneOneHalfPlaceholder2.Text = "Valve model number: PR" + ptfeChecker2 + "150" + sealMaterialCode + "-" + bodyMaterialCode;
                        OneOneHalfPlaceholder2.IsVisible = true;
                        OneOneHalfButton.IsVisible = true;
                        oneOneHalfCode = "PR" + ptfeChecker2 + "150" + sealMaterialCode + "-" + bodyMaterialCode;
                        break;
                    }
                    else if (_requiredFlowRate < OneOneHalfArray[0, i])
                    {
                        OneOneHalfPlaceholder.Text = "1 1/2\" valve, pressure drop at " + _requiredFlowRate + " GPM: between " + OneOneHalfArray[1, i - 1] + " and " + OneOneHalfArray[1, i] + " PSI";
                        OneOneHalfPlaceholder.IsVisible = true;
                        OneOneHalfPlaceholder2.Text = "Valve model number: PR" + ptfeChecker2 + "150" + sealMaterialCode + "-" + bodyMaterialCode;
                        OneOneHalfPlaceholder2.IsVisible = true;
                        OneOneHalfButton.IsVisible = true;
                        oneOneHalfCode = "PR" + ptfeChecker2 + "150" + sealMaterialCode + "-" + bodyMaterialCode;
                        break;
                    }
                }
            }
            // 2" Valves
            if (_requiredFlowRate >= TwoWholeArray[0, 0] && _requiredFlowRate <= TwoWholeArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == TwoWholeArray[0, i])
                    {
                        TwoWholePlaceholder.Text = "2\" valve, pressure drop at " + _requiredFlowRate + " GPM: " + TwoWholeArray[1, i] + " PSI";
                        TwoWholePlaceholder.IsVisible = true;
                        if (valveBodyMaterial != 3)
                        {
                            TwoWholePlaceholder2.Text = "Valve model number: PRHM200" + sealMaterialCode + "-" + bodyMaterialCode;
                            TwoWholePlaceholder2.IsVisible = true;
                            TwoWholeButton.IsVisible = true;
                            twoWholeCode = "PRHM200" + sealMaterialCode + "-" + bodyMaterialCode;
                        }
                        else
                        {
                            TwoWholePlaceholder2.Text = "Valve model number: Consult Factory";
                            TwoWholePlaceholder2.FontAttributes = FontAttributes.Italic | FontAttributes.Bold;
                            TwoWholePlaceholder2.IsVisible = true;
                        }
                        break;
                    }
                    else if (_requiredFlowRate < TwoWholeArray[0, i])
                    {
                        TwoWholePlaceholder.Text = "2\" valve, pressure drop at " + _requiredFlowRate + " GPM: between " + TwoWholeArray[1, i - 1] + " and " + TwoWholeArray[1, i] + " PSI";
                        TwoWholePlaceholder.IsVisible = true;
                        if (valveBodyMaterial != 3)
                        {
                            TwoWholePlaceholder2.Text = "Valve model number: PRHM200" + sealMaterialCode + "-" + bodyMaterialCode;
                            TwoWholePlaceholder2.IsVisible = true;
                            TwoWholeButton.IsVisible = true;
                            twoWholeCode = "PRHM200" + sealMaterialCode + "-" + bodyMaterialCode;
                        }
                        else
                        {
                            TwoWholePlaceholder2.Text = "Valve model number: Consult Factory";
                            TwoWholePlaceholder2.FontAttributes = FontAttributes.Italic | FontAttributes.Bold;
                            TwoWholePlaceholder2.IsVisible = true;
                        }
                        break;
                    }
                }
            }
            // 3" Valves
            if (_requiredFlowRate >= ThreeWholeArray[0, 0] && _requiredFlowRate <= ThreeWholeArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == ThreeWholeArray[0, i])
                    {
                        ThreeWholePlaceholder.Text = "3\" valve, pressure drop at " + _requiredFlowRate + " GPM: " + ThreeWholeArray[1, i] + " PSI";
                        ThreeWholePlaceholder.IsVisible = true;
                        if (valveBodyMaterial != 1 && valveBodyMaterial != 3)
                        {
                            ThreeWholePlaceholder2.Text = "Valve model number: PR" + ptfeChecker3 + "300" + sealMaterialCode + "-" + bodyMaterialCode;
                            ThreeWholePlaceholder2.IsVisible = true;
                            ThreeWholeButton.IsVisible = true;
                            threeWholeCode = "PR" + ptfeChecker3 + "300" + sealMaterialCode + "-" + bodyMaterialCode;
                        }
                        else
                        {
                            ThreeWholePlaceholder2.Text = "Valve model number: Consult Factory";
                            ThreeWholePlaceholder2.FontAttributes = FontAttributes.Italic | FontAttributes.Bold;
                            ThreeWholePlaceholder2.IsVisible = true;
                        }

                        break;
                    }
                    else if (_requiredFlowRate < ThreeWholeArray[0, i])
                    {
                        ThreeWholePlaceholder.Text = "3\" valve, pressure drop at " + _requiredFlowRate + " GPM: between " + ThreeWholeArray[1, i - 1] + " and " + ThreeWholeArray[1, i] + " PSI";
                        ThreeWholePlaceholder.IsVisible = true;
                        if (valveBodyMaterial != 1 && valveBodyMaterial != 3)
                        {
                            ThreeWholePlaceholder2.Text = "Valve model number: PR" + ptfeChecker3 + "300" + sealMaterialCode + "-" + bodyMaterialCode;
                            ThreeWholePlaceholder2.IsVisible = true;
                            ThreeWholeButton.IsVisible = true;
                            threeWholeCode = "PR" + ptfeChecker3 + "300" + sealMaterialCode + "-" + bodyMaterialCode;
                        }
                        else
                        {
                            ThreeWholePlaceholder2.Text = "Valve model number: Consult Factory";
                            ThreeWholePlaceholder2.FontAttributes = FontAttributes.Italic | FontAttributes.Bold;
                            ThreeWholePlaceholder2.IsVisible = true;
                        }

                        break;
                    }
                }
            }
        } // End of PHRM Method

        public void CalculateUPR(int? connectionType, int _requiredFlowRate, double[,] OneFourthArray, double[,] OneHalfArray, double[,] ThreeFourthArray, double[,] OneWholeArray, double[,] OneOneHalfArray, double[,] TwoWholeArray, double[,] ThreeWholeArray)
        {
            string connectionTypeCode = "";
            switch (connectionType)
            {
                case 0: // Asahi Spigot
                    ConnectionTypeLabel.Text = "Asahi";
                    connectionTypeCode = "1";
                    break;
                case 1: // GF Spigot
                    ConnectionTypeLabel.Text = "GF";
                    connectionTypeCode = "2";
                    break;
                case 2: // IPS Spigot
                    ConnectionTypeLabel.Text = "IPS";
                    connectionTypeCode = "3";
                    break;
            }

            if (_requiredFlowRate >= OneFourthArray[0, 0] && _requiredFlowRate <= OneFourthArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == OneFourthArray[0, i])
                    {
                        OneFourthPlaceholder.Text = "1/4\" valve, pressure drop at " + _requiredFlowRate + " GPM: " + OneFourthArray[1, i] + " PSI";
                        OneFourthPlaceholder.IsVisible = true;
                        OneFourthPlaceholder2.Text = "Valve model number: UPR025TT-PF (Threaded)";
                        OneFourthPlaceholder2.IsVisible = true;
                        OneFourthButton.IsVisible = true;
                        oneFourthCode = "UPR025TT-PF";
                        OneFourthPlaceholder3.Text = "1/4\" valve, pressure drop at " + _requiredFlowRate + " GPM: " + OneFourthArray[1, i] + " PSI";
                        OneFourthPlaceholder3.IsVisible = true;
                        OneFourthPlaceholder4.Text = "Valve model number: UPR025TFR-PF (Flare)";
                        OneFourthPlaceholder4.IsVisible = true;
                        OneFourthButton2.IsVisible = true;
                        oneFourthCode2 = "UPR025TFR-PF";
                        break;
                    }
                    else if (_requiredFlowRate < OneFourthArray[0, i])
                    {
                        OneFourthPlaceholder.Text = "1/4\" valve, pressure drop at " + _requiredFlowRate + " GPM: between " + OneFourthArray[1, i - 1] + " and " + OneFourthArray[1, i] + " PSI";
                        OneFourthPlaceholder.IsVisible = true;
                        OneFourthPlaceholder2.Text = "Valve model number: UPR025TT-PF (Threaded)";
                        OneFourthPlaceholder2.IsVisible = true;
                        OneFourthButton.IsVisible = true;
                        oneFourthCode = "UPR025TT-PF";
                        OneFourthPlaceholder3.Text = "1/4\" valve, pressure drop at " + _requiredFlowRate + " GPM: between " + OneFourthArray[1, i - 1] + " and " + OneFourthArray[1, i] + " PSI";
                        OneFourthPlaceholder3.IsVisible = true;
                        OneFourthPlaceholder4.Text = "Valve model number: UPR025TFR-PF (Flare)";
                        OneFourthPlaceholder4.IsVisible = true;
                        OneFourthButton2.IsVisible = true;
                        oneFourthCode2 = "UPR025TFR-PF";
                        break;
                    }
                }
            }
            if (_requiredFlowRate >= OneHalfArray[0, 0] && _requiredFlowRate <= OneHalfArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == OneHalfArray[0, i])
                    {
                        OneHalfPlaceholder.Text = "20 mm valve, pressure drop at " + _requiredFlowRate + " GPM: " + OneHalfArray[1, i] + " PSI";
                        OneHalfPlaceholder.IsVisible = true;
                        OneHalfPlaceholder2.Text = "Valve model number: UPR20TSP" + connectionTypeCode + "-PF";
                        OneHalfPlaceholder2.IsVisible = true;
                        OneHalfButton.IsVisible = true;
                        oneHalfCode = "UPR20TSP" + connectionTypeCode + "-PF";                      
                        break;
                    }
                    else if (_requiredFlowRate < OneHalfArray[0, i])
                    {
                        OneHalfPlaceholder.Text = "1/2\" valve, pressure drop at " + _requiredFlowRate + " GPM: between " + OneHalfArray[1, i - 1] + " and " + OneHalfArray[1, i] + " PSI";
                        OneHalfPlaceholder.IsVisible = true;
                        OneHalfPlaceholder2.Text = "Valve model number: UPR20TSP" + connectionTypeCode + "-PF";
                        OneHalfPlaceholder2.IsVisible = true;
                        OneHalfButton.IsVisible = true;
                        oneHalfCode = "UPR20TSP" + connectionTypeCode + "-PF";
                        break;
                    }
                }
            }

            if (_requiredFlowRate >= ThreeFourthArray[0, 0] && _requiredFlowRate <= ThreeFourthArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == ThreeFourthArray[0, i])
                    {
                        ThreeFourthPlaceholder.Text = "25 mm valve, pressure drop at " + _requiredFlowRate + " GPM: " + ThreeFourthArray[1, i] + " PSI";
                        ThreeFourthPlaceholder.IsVisible = true;
                        ThreeFourthPlaceholder2.Text = "Valve model number: UPR25TSP" + connectionTypeCode + "-PF";
                        ThreeFourthPlaceholder2.IsVisible = true;
                        ThreeFourthButton.IsVisible = true;
                        threeFourthCode = "UPR25TSP" + connectionTypeCode + "-PF";
                        break;
                    }
                    else if (_requiredFlowRate < ThreeFourthArray[0, i])
                    {
                        ThreeFourthPlaceholder.Text = "25 mm valve, pressure drop at " + _requiredFlowRate + " GPM: between " + ThreeFourthArray[1, i - 1] + " and " + ThreeFourthArray[1, i] + " PSI";
                        ThreeFourthPlaceholder.IsVisible = true;
                        ThreeFourthPlaceholder2.Text = "Valve model number: UPR25TSP" + connectionTypeCode + "-PF";
                        ThreeFourthPlaceholder2.IsVisible = true;
                        ThreeFourthButton.IsVisible = true;
                        threeFourthCode = "UPR25TSP" + connectionTypeCode + "-PF";
                        break;
                    }
                }
            }

            if (_requiredFlowRate >= OneWholeArray[0, 0] && _requiredFlowRate <= OneWholeArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == OneWholeArray[0, i])
                    {
                        OneWholePlaceholder.Text = "32 mm valve, pressure drop at " + _requiredFlowRate + " GPM: " + OneWholeArray[1, i] + " PSI";
                        OneWholePlaceholder.IsVisible = true;
                        OneWholePlaceholder2.Text = "Valve model number: UPR32TSP" + connectionTypeCode + "-PF";
                        OneWholePlaceholder2.IsVisible = true;
                        OneWholeButton.IsVisible = true;
                        oneWholeCode = "UPR32TSP" + connectionTypeCode + "-PF";
                        break;
                    }
                    else if (_requiredFlowRate < OneWholeArray[0, i])
                    {
                        OneWholePlaceholder.Text = "32 mm valve, pressure drop at " + _requiredFlowRate + " GPM: between " + OneWholeArray[1, i - 1] + " and " + OneWholeArray[1, i] + " PSI";
                        OneWholePlaceholder.IsVisible = true;
                        OneWholePlaceholder2.Text = "Valve model number: UPR32TSP" + connectionTypeCode + "-PF";
                        OneWholePlaceholder2.IsVisible = true;
                        OneWholeButton.IsVisible = true;
                        oneWholeCode = "UPR32TSP" + connectionTypeCode + "-PF";
                        break;
                    }
                }
            }

            if (_requiredFlowRate >= OneOneHalfArray[0, 0] && _requiredFlowRate <= OneOneHalfArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == OneOneHalfArray[0, i])
                    {
                        OneOneHalfPlaceholder.Text = "50 mm valve, pressure drop at " + _requiredFlowRate + " GPM: " + OneOneHalfArray[1, i] + " PSI";
                        OneOneHalfPlaceholder.IsVisible = true;
                        OneOneHalfPlaceholder2.Text = "Valve model number: UPR50TSP" + connectionTypeCode + "-PF";
                        OneOneHalfPlaceholder2.IsVisible = true;
                        OneOneHalfButton.IsVisible = true;
                        oneOneHalfCode = "UPR50TSP" + connectionTypeCode + "-PF";
                        break;
                    }
                    else if (_requiredFlowRate < OneOneHalfArray[0, i])
                    {
                        OneOneHalfPlaceholder.Text = "50 mm valve, pressure drop at " + _requiredFlowRate + " GPM: between " + OneOneHalfArray[1, i - 1] + " and " + OneOneHalfArray[1, i] + " PSI";
                        OneOneHalfPlaceholder.IsVisible = true;
                        OneOneHalfPlaceholder2.Text = "Valve model number: UPR50TSP" + connectionTypeCode + "-PF";
                        OneOneHalfPlaceholder2.IsVisible = true;
                        OneOneHalfButton.IsVisible = true;
                        oneOneHalfCode = "UPR50TSP" + connectionTypeCode + "-PF";
                        break;
                    }
                }
            }

            if (_requiredFlowRate >= TwoWholeArray[0, 0] && _requiredFlowRate <= TwoWholeArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_requiredFlowRate == TwoWholeArray[0, i])
                    {
                        TwoWholePlaceholder.Text = "63 mm valve, pressure drop at " + _requiredFlowRate + " GPM: " + TwoWholeArray[1, i] + " PSI";
                        TwoWholePlaceholder.IsVisible = true;
                        TwoWholePlaceholder2.Text = "Valve model number: UPR63TSP" + connectionTypeCode + "-PF";
                        TwoWholePlaceholder2.IsVisible = true;
                        TwoWholeButton.IsVisible = true;
                        twoWholeCode = "UPR63TSP" + connectionTypeCode + "-PF";
                        break;
                    }
                    else if (_requiredFlowRate < TwoWholeArray[0, i])
                    {
                        TwoWholePlaceholder.Text = "63 mm valve, pressure drop at " + _requiredFlowRate + " GPM: between " + TwoWholeArray[1, i - 1] + " and " + TwoWholeArray[1, i] + " PSI";
                        TwoWholePlaceholder.IsVisible = true;
                        TwoWholePlaceholder2.Text = "Valve model number: UPR63TSP" + connectionTypeCode + "-PF";
                        TwoWholePlaceholder2.IsVisible = true;
                        TwoWholeButton.IsVisible = true;
                        twoWholeCode = "UPR63TSP" + connectionTypeCode + "-PF";
                        break;
                    }
                }
            }

        } // End of UPR Method


        }
}