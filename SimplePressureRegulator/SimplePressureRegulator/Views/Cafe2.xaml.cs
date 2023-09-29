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
    public partial class Cafe2 : ContentPage
    {
        string _actuatorModel = "";
        string _modelSuffix = "";
        string _actuatorType = "";
        string _controlOptions = "";
        string _valveSize = "";
        string _sealMaterial = "";
        string _connectionType = "";
        string _bodyMaterial = "";
        string _ballOptions = "";
        string _PartNumber;
        // START: Using INotifyPropertyChanged to update the xaml view
        public ObservableRangeCollection<Product> CafeProduct;
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

        public Cafe2(int? valveType, int? oledDisplay, int? actuatorSpeed, string _actuatorSpeed, int? controlOptions, string __controlOptions, string connectionType, string valveSize, string bodyMaterial, int? sealMaterial, string ballOptions)
        {
            InitializeComponent();
            BindingContext = this;

            switch (valveType)
            {
                case 0: // 2-way
                    ValveTypeLabel.Text = "2-way";
                    _actuatorType = "1";
                    _actuatorModel = "CAFE";
                    break;
                case 1: // 3-way
                    ValveTypeLabel.Text = "3-way";
                    _actuatorType = "5";
                    _actuatorModel = "TCAFE";
                    break;
            }

            switch (oledDisplay)
            {
                case 0:
                    OLEDLabel.Text = "Yes";
                    break;
                case 1:
                    OLEDLabel.Text = "No";
                    SpeedLabel.IsVisible = false;
                    SpeedLabel2.IsVisible = false;
                    ControlOptionsLabel.IsVisible = false;
                    ControlOptionsLabel2.IsVisible = false;
                    Grid.SetRow(ConnectionTypeLabel, 2);
                    Grid.SetRow(ConnectionTypeLabel2, 2);
                    Grid.SetRow(SizeLabel, 3);
                    Grid.SetRow(SizeLabel2, 3);
                    Grid.SetRow(MaterialLabel, 4);
                    Grid.SetRow(MaterialLabel2, 4);
                    Grid.SetRow(SealMaterialLabel, 5);
                    Grid.SetRow(SealMaterialLabel2, 5);
                    Grid.SetRow(BallOptionsLabel, 6);
                    Grid.SetRow(BallOptionsLabel2, 6);
                    break;
            }
            
            switch (actuatorSpeed)
            {
                case 0: // Standard Speed
                    _modelSuffix = "N";
                    break;
                case 1: // High Speed
                    _modelSuffix = "F";
                    break;
            }
            SpeedLabel.Text = _actuatorSpeed;

            if (controlOptions == null)
            {
                controlOptions = 0;
            }
            _controlOptions = (controlOptions + 1).ToString();
            ControlOptionsLabel.Text = __controlOptions;

            if (valveSize == "3/8\"")
            {
                _valveSize = "037";
            }
            else if (valveSize == "1/2\"")
            {
                _valveSize = "050";
            }
            else if (valveSize == "3/4\"" || valveSize == "3/4\" Mini")
            {
                _valveSize = "075";
            }
            else if (valveSize == "1\"" || valveSize == "1\" Maxi" || valveSize == "1\" Ladish")
            {
                _valveSize = "100";
            }
            else if (valveSize == "1 1/4\"")
            {
                _valveSize = "125";
            }
            else if (valveSize == "1 1/2\"")
            {
                _valveSize = "150";
            }
            else if (valveSize == "2\"")
            {
                _valveSize = "200";
            }
            else if (valveSize == "20mm")
            {
                _valveSize = "20";
            }
            else if (valveSize == "25mm")
            {
                _valveSize = "25";
            }
            else if (valveSize == "32mm")
            {
                _valveSize = "32";
            }
            else if (valveSize == "40mm")
            {
                _valveSize = "40";
            }
            else if (valveSize == "50mm")
            {
                _valveSize = "50";
            }
            else if (valveSize == "63mm")
            {
                _valveSize = "63";
            }
            SizeLabel.Text = valveSize;

            switch (sealMaterial)
            {
                case 0:
                    _sealMaterial = "V";
                    SealMaterialLabel.Text = "Viton";
                    break;
                case 1:
                    _sealMaterial = "EP";
                    SealMaterialLabel.Text = "EPDM";
                    break;
            }

            if (connectionType == "NPT Threads")
            {
                _connectionType = "T";
            }
            else if (connectionType == "Metric Socket" || connectionType == "IPS Socket")
            {
                _connectionType = "S";
            }
            else if (connectionType == "BSP Threads")
            {
                _connectionType = "BSP";
            }
            else if (connectionType == "ANSI 150 Flanges")
            {
                _connectionType = "FL";
            }
            else if (connectionType == "Asahi Spigot")
            {
                _connectionType = "SP1";
            }
            else if (connectionType == "GF+ Spigot")
            {
                _connectionType = "SP2";
            }
            else if (connectionType == "SCH. 80 Spigot")
            {
                _connectionType = "SP3";
            }
            else if (connectionType == "Sanitary Tri-Clamp")
            {
                _connectionType = "SC";
            }
            ConnectionTypeLabel.Text = connectionType;



            if (bodyMaterial == "PVC")
            {
                _bodyMaterial = "PV";
            }
            else if (bodyMaterial == "CPVC")
            {
                _bodyMaterial = "CP";
            }
            else if (bodyMaterial == "Polypro")
            {
                _bodyMaterial = "PP";
            }
            else if (bodyMaterial == "PVDF")
            {
                _bodyMaterial = "PF";
            }
            else if (bodyMaterial == "Red PVDF")
            {
                _bodyMaterial = "RPF";
            }
            MaterialLabel.Text = bodyMaterial;



            if (ballOptions == "3-way Ball")
            {
                _ballOptions = "-A";
            }
            else if (ballOptions == "Linear Flow Ball")
            {
                _ballOptions = "-CLF";
            }
            else if (ballOptions == "Vented Ball")
            {
                _ballOptions = "-VENT";
            }
            else if (ballOptions == "15° V-Cut Ball")
            {
                _ballOptions = "-C1";
            }
            else if (ballOptions == "30° V-Cut Ball")
            {
                _ballOptions = "-C3";
            }
            else if (ballOptions == "45° V-Cut Ball")
            {
                _ballOptions = "-C4";
            }
            else if (ballOptions == "60° V-Cut Ball")
            {
                _ballOptions = "-C6";
            }
            else if (ballOptions == "90° V-Cut Ball")
            {
                _ballOptions = "-C9";
            }
            BallOptionsLabel.Text = ballOptions;

            _PartNumber = _actuatorModel + _modelSuffix + _actuatorType + "-" + _controlOptions + "-" + _valveSize + _sealMaterial + _connectionType + "-" + _bodyMaterial + _ballOptions;

            GetProduct(valveType.ToString(), controlOptions.ToString());

        } // End of Main Method

        async Task GetProduct(string valveType, string controlOptions)
        {
            IsBusy = true;
            CafeProduct = new ObservableRangeCollection<Product>();
            Product = new ObservableRangeCollection<Product>();
            var products = await InternetProductService.GetCAFE(valveType, controlOptions);
            CafeProduct.AddRange(products);
            CafeProduct[0].PartNumber = _PartNumber;
            Product.AddRange(CafeProduct);
            IsBusy = false;
        }

        private async void OnTapped(object sender, EventArgs e)
        {
            var button = (StackLayout)sender;
            var url = "https://plastomatic.com/wp-content/uploads/2023/05/CAFE-NITRO-Catalog-0523-Chronos-option.pdf";
            await Browser.OpenAsync(url);
        }
    }
}