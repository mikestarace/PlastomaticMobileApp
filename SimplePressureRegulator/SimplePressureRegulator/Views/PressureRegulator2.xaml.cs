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
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PressureRegulator2 : ContentPage
    {
        // START: Using INotifyPropertyChanged to update the xaml view        
        private ObservableRangeCollection<Product> _products;
        public ObservableRangeCollection<Product> Product
        {
            get { return _products; }
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged();
                }
            }
        } // END: Using INotifyPropertyChanged to update the xaml view

        public PressureRegulator2(string _valveApplication, string _desiredSetPressure, string _bodyMaterial, string _sealMaterial, string _spigotType, string _gauge, string _valveSize, string _maxInletPressure, int? desiredSetPressure, int? valveSize, int? maxInletPressure, int requiredFlowRate)
        {
            InitializeComponent();
            BindingContext = this;
            ValveApplicationLabel.Text = _valveApplication;
            DesiredSetPressureLabel.Text = _desiredSetPressure;
            MaterialLabel.Text = _bodyMaterial;
            SealMaterialLabel.Text = _sealMaterial;
            SpigotTypeLabel.Text = _spigotType;
            GaugeLabel.Text = _gauge;
            PipeSizeLabel.Text = _valveSize;
            MaxSystemInletLabel.Text = _maxInletPressure;
            RequiredFlowRateLabel.Text = requiredFlowRate.ToString() + " GPM";
            string[] sizes = new string[7];
            sizes[0] = "1/2\"";
            sizes[1] = "3/4\"";
            sizes[2] = "1\"";
            sizes[3] = "1 1/4\"";
            sizes[4] = "1 1/2\"";
            sizes[5] = "2\"";
            sizes[6] = "3\"";


            if (_valveApplication == "High Performance Pressure Regulator" || _valveApplication == "Differential Pressure Regulator")
            {
                SealMaterialLabel.IsVisible = true;
                SealMaterialLabel1.IsVisible = true;
            } else if (_valveApplication == "Ultra-Pure Metal Ion-Free EPDM" || _valveApplication == "Ultra-Pure Elastomer Free")
            {
                SpigotTypeLabel.IsVisible = true;
                SpigotTypeLabel1.IsVisible = true;
                MaterialLabel.Text = "PVDF";
                if(_spigotType != "IPS")
                {
                    sizes[0] = "20 mm";
                    sizes[1] = "25 mm";
                    sizes[2] = "32 mm";
                    sizes[3] = "40 mm";
                    sizes[4] = "50 mm";
                    sizes[5] = "63 mm";
                    sizes[6] = "90 mm";
                }
            } else if (_valveApplication == "Ultra-Pure Shutoff Design")
            {
                SpigotTypeLabel.IsVisible = true;
                SpigotTypeLabel1.IsVisible = true;
                MaterialLabel.Text = "PVDF";
                Grid.SetRow(RequiredFlowRateLabel, 6);
                Grid.SetRow(RequiredFlowRateLabel1, 6);
                GaugeLabel.IsVisible = true;
                GaugeLabel1.IsVisible = true;
                sizes[0] = "20 mm";
                sizes[1] = "25 mm";
                sizes[2] = "32 mm";
                sizes[3] = "40 mm";
                sizes[4] = "50 mm";
                sizes[5] = "63 mm";
                sizes[6] = "90 mm";
            }

            List<string> sizeList = new List<string>();
            
            if (requiredFlowRate >= 1 && requiredFlowRate <= 5)
            {
                sizeList.Add("OneFourth");
            }
            if (requiredFlowRate >= 1.5 && requiredFlowRate <= 10)
            {
                sizeList.Add("OneHalf");
                sizeList.Add("20 mm");
            }
            if (requiredFlowRate >= 8 && requiredFlowRate <= 35)
            {
                sizeList.Add("ThreeFourth");
                sizeList.Add("25 mm");
            }
            if (requiredFlowRate >= 11 && requiredFlowRate <= 50)
            {
                sizeList.Add("OneWhole");
                sizeList.Add("32 mm");
            }
            if (requiredFlowRate >= 16 && requiredFlowRate <= 70)
            {
                sizeList.Add("OneOneFourth");
                sizeList.Add("OneOneHalf");
                sizeList.Add("40 mm");
                sizeList.Add("50 mm");
            }
            if (requiredFlowRate >= 20 && requiredFlowRate <= 100)
            {
                sizeList.Add("TwoWhole");
                sizeList.Add("63 mm");
            }
            if (requiredFlowRate >= 50 && requiredFlowRate <= 200)
            {
                sizeList.Add("ThreeWhole");
                sizeList.Add("90 mm");
            }

            GetProduct(_valveApplication, sizeList, _bodyMaterial, _sealMaterial, _spigotType, _gauge);

            // CREATING THE 3D ARRAY
            double[,] arrayGPM = new double[14, 5];
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
            int arrayYvalue = desiredSetPressure.Value;

            if (arrayYvalue > 4)
            {
                arrayYvalue = 4;
            }

            // GETTING THE MAX FLOW RATE AND ATTACHING IT TO THE LABEL
            double maxFlowRate = arrayGPM[arrayXvalue.Value, arrayYvalue];
            if (maxFlowRate < requiredFlowRate)
            {
                GPMLabel.Text = "Max flow rate: " + maxFlowRate.ToString() + " GPM (WARNING: your requested flow rate exceeds the max flow rate)";
                GPMLabel.TextColor = Color.Red;
            }
            if (maxFlowRate >= requiredFlowRate)
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

            CalculatePressureDrop(requiredFlowRate, OneFourthArray, OneHalfArray, ThreeFourthArray, OneWholeArray, OneOneHalfArray, TwoWholeArray, ThreeWholeArray, sizes);
        } // End of Main Method

        void CalculatePressureDrop(int requiredFlowRate, double[,] OneFourthArray, double[,] OneHalfArray, double[,] ThreeFourthArray, double[,] OneWholeArray, double[,] OneOneHalfArray, double[,] TwoWholeArray, double[,] ThreeWholeArray, string[] sizes)
        {
            // 1/4" Valves
            if (requiredFlowRate >= OneFourthArray[0, 0] && requiredFlowRate <= OneFourthArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (requiredFlowRate == OneFourthArray[0, i])
                    {
                        OneFourthPlaceholder.Text = "1/4\" valve, pressure drop at " + requiredFlowRate + " GPM: " + OneFourthArray[1, i] + " PSI";
                        OneFourthPlaceholder.IsVisible = true;
                        break;
                    }
                    else if (requiredFlowRate < OneFourthArray[0, i])
                    {
                        OneFourthPlaceholder.Text = "1/4\" valve, pressure drop at " + requiredFlowRate + " GPM: between " + OneFourthArray[1, i - 1] + " and " + OneFourthArray[1, i] + " PSI";
                        OneFourthPlaceholder.IsVisible = true;
                        break;
                    }
                }
            }
            // 1/2" Valves
            if (requiredFlowRate >= OneHalfArray[0, 0] && requiredFlowRate <= OneHalfArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (requiredFlowRate == OneHalfArray[0, i])
                    {
                        OneHalfPlaceholder.Text = sizes[0] + " valve, pressure drop at " + requiredFlowRate + " GPM: " + OneHalfArray[1, i] + " PSI";
                        OneHalfPlaceholder.IsVisible = true;
                        break;
                    }
                    else if (requiredFlowRate < OneHalfArray[0, i])
                    {
                        OneHalfPlaceholder.Text = sizes[0] + " valve, pressure drop at " + requiredFlowRate + " GPM: between " + OneHalfArray[1, i - 1] + " and " + OneHalfArray[1, i] + " PSI";
                        OneHalfPlaceholder.IsVisible = true;
                        break;
                    }
                }
            }
            // 3/4" Valves
            if (requiredFlowRate >= ThreeFourthArray[0, 0] && requiredFlowRate <= ThreeFourthArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (requiredFlowRate == ThreeFourthArray[0, i])
                    {
                        ThreeFourthPlaceholder.Text = sizes[1] + " valve, pressure drop at " + requiredFlowRate + " GPM: " + ThreeFourthArray[1, i] + " PSI";
                        ThreeFourthPlaceholder.IsVisible = true;
                        break;
                    }
                    else if (requiredFlowRate < ThreeFourthArray[0, i])
                    {
                        ThreeFourthPlaceholder.Text = sizes[1] + " valve, pressure drop at " + requiredFlowRate + " GPM: between " + ThreeFourthArray[1, i - 1] + " and " + ThreeFourthArray[1, i] + " PSI";
                        ThreeFourthPlaceholder.IsVisible = true;
                        break;
                    }
                }
            }
            // 1" Valves
            if (requiredFlowRate >= OneWholeArray[0, 0] && requiredFlowRate <= OneWholeArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (requiredFlowRate == OneWholeArray[0, i])
                    {
                        OneWholePlaceholder.Text = sizes[2] + " valve, pressure drop at " + requiredFlowRate + " GPM: " + OneWholeArray[1, i] + " PSI";
                        OneWholePlaceholder.IsVisible = true;
                        break;
                    }
                    else if (requiredFlowRate < OneWholeArray[0, i])
                    {
                        OneWholePlaceholder.Text = sizes[2] + " valve, pressure drop at " + requiredFlowRate + " GPM: between " + OneWholeArray[1, i - 1] + " and " + OneWholeArray[1, i] + " PSI";
                        OneWholePlaceholder.IsVisible = true;
                        break;
                    }
                }
            }
            //1 1/4" Valves
            if (requiredFlowRate >= OneOneHalfArray[0, 0] && requiredFlowRate <= OneOneHalfArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (requiredFlowRate == OneOneHalfArray[0, i])
                    {
                        OneOneFourthPlaceholder.Text = sizes[3] + " valve, pressure drop at " + requiredFlowRate + " GPM: " + OneOneHalfArray[1, i] + " PSI";
                        OneOneFourthPlaceholder.IsVisible = true;
                        break;
                    }
                    else if (requiredFlowRate < OneOneHalfArray[0, i])
                    {
                        OneOneFourthPlaceholder.Text = sizes[3] + " valve, pressure drop at " + requiredFlowRate + " GPM: between " + OneOneHalfArray[1, i - 1] + " and " + OneOneHalfArray[1, i] + " PSI";
                        OneOneFourthPlaceholder.IsVisible = true;
                        break;
                    }
                }
            }
            //1 1/2" Valves
            if (requiredFlowRate >= OneOneHalfArray[0, 0] && requiredFlowRate <= OneOneHalfArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (requiredFlowRate == OneOneHalfArray[0, i])
                    {
                        OneOneHalfPlaceholder.Text = sizes[4] + " valve, pressure drop at " + requiredFlowRate + " GPM: " + OneOneHalfArray[1, i] + " PSI";
                        OneOneHalfPlaceholder.IsVisible = true;
                        break;
                    }
                    else if (requiredFlowRate < OneOneHalfArray[0, i])
                    {
                        OneOneHalfPlaceholder.Text = sizes[4] + " valve, pressure drop at " + requiredFlowRate + " GPM: between " + OneOneHalfArray[1, i - 1] + " and " + OneOneHalfArray[1, i] + " PSI";
                        OneOneHalfPlaceholder.IsVisible = true;
                        break;
                    }
                }
            }
            // 2" Valves
            if (requiredFlowRate >= TwoWholeArray[0, 0] && requiredFlowRate <= TwoWholeArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (requiredFlowRate == TwoWholeArray[0, i])
                    {
                        TwoWholePlaceholder.Text = sizes[5] + " valve, pressure drop at " + requiredFlowRate + " GPM: " + TwoWholeArray[1, i] + " PSI";
                        TwoWholePlaceholder.IsVisible = true;
                        break;
                    }
                    else if (requiredFlowRate < TwoWholeArray[0, i])
                    {
                        TwoWholePlaceholder.Text = sizes[5] + " valve, pressure drop at " + requiredFlowRate + " GPM: between " + TwoWholeArray[1, i - 1] + " and " + TwoWholeArray[1, i] + " PSI";
                        TwoWholePlaceholder.IsVisible = true;
                        break;
                    }
                }
            }
            // 3" Valves
            if (requiredFlowRate >= ThreeWholeArray[0, 0] && requiredFlowRate <= ThreeWholeArray[0, 4])
            {
                for (int i = 0; i < 5; i++)
                {
                    if (requiredFlowRate == ThreeWholeArray[0, i])
                    {
                        ThreeWholePlaceholder.Text = sizes[6] + " valve, pressure drop at " + requiredFlowRate + " GPM: " + ThreeWholeArray[1, i] + " PSI";
                        ThreeWholePlaceholder.IsVisible = true;
                        break;
                    }
                    else if (requiredFlowRate < ThreeWholeArray[0, i])
                    {
                        ThreeWholePlaceholder.Text = sizes[6] + " valve, pressure drop at " + requiredFlowRate + " GPM: between " + ThreeWholeArray[1, i - 1] + " and " + ThreeWholeArray[1, i] + " PSI";
                        ThreeWholePlaceholder.IsVisible = true;
                        break;
                    }
                }
            }
        } // End of Calculate Pressure Drop Method

        async Task GetProduct(string _valveApplication, List<string> sizeArray, string _bodyMaterial, string _sealMaterial, string _spigotType, string _gauge)
        {
            Product = new ObservableRangeCollection<Product>();
            if (_valveApplication == "High Performance Pressure Regulator")
            {
                foreach (var valveSize in sizeArray)
                {
                    var products = await InternetProductService.GetPRHM(valveSize, _bodyMaterial, _sealMaterial);
                    Product.AddRange(products);
                }
            }
            else if (_valveApplication == "Differential Pressure Regulator")
            {
                foreach (var valveSize in sizeArray)
                {
                    var products = await InternetProductService.GetPRD(valveSize, _bodyMaterial, _sealMaterial);
                    Product.AddRange(products);
                }
            }
            else if (_valveApplication == "Ultra-Pure Metal Ion-Free EPDM")
            {
                foreach (var valveSize in sizeArray)
                {
                    var products = await InternetProductService.GetPRHU(valveSize, _spigotType);
                    Product.AddRange(products);
                }
            }
            else if (_valveApplication == "Ultra-Pure Elastomer Free")
            {
                foreach (var valveSize in sizeArray)
                {
                    var products = await InternetProductService.GetUPR(valveSize, _spigotType);
                    Product.AddRange(products);
                }
            }
            else if (_valveApplication == "Ultra-Pure Shutoff Design")
            {
                foreach (var valveSize in sizeArray)
                {
                    var products = await InternetProductService.GetUPRS(valveSize, _spigotType, _gauge);
                    Product.AddRange(products);
                }
            }
        }
    }
}