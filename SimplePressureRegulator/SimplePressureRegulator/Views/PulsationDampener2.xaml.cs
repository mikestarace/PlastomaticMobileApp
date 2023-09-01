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
    public partial class PulsationDampener2 : ContentPage
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

        public PulsationDampener2(string _pipeDiameter, string _pipeLength, string _linePressure, string _bodyMaterial, string _sealMaterial, int? pipeDiameter, int? pipeLength, int? linePressure, int? bodyMaterial, int? sealMaterial)
        {
            InitializeComponent();
            BindingContext = this;
            PipeDiameterLabel.Text = _pipeDiameter;
            PipeLengthLabel.Text = _pipeLength;
            LinePressureLabel.Text = _linePressure;
            MaterialLabel.Text = _bodyMaterial;
            SealMaterialLabel.Text = _sealMaterial;
            string _flowRate = "";
            switch (pipeDiameter)
            {
                case 0:
                    _flowRate = "1.02";
                    break;
                case 1:
                    _flowRate = "2.03";
                    break;
                case 2:
                    _flowRate = "3.41";
                    break;
                case 3:
                    _flowRate = "6.42";
                    break;
                case 4:
                    _flowRate = "10.7";
                    break;
                case 5:
                    _flowRate = "26.67";
                    break;
                case 6:
                    _flowRate = "44.8";
                    break;
            }
            FlowRateLabel.Text = "Flow rate: " + _flowRate + " GPM";

            List<string> sizeList = new List<string>();
            sizeList.Add("OneWhole");

            if (linePressure == 0)
            {
                if ((pipeDiameter == 3 && pipeLength == 3) || (pipeDiameter == 4 && pipeLength == 2) || (pipeDiameter == 5 && pipeLength == 1) || (pipeDiameter == 5 && pipeLength == 3) || (pipeDiameter == 6 && pipeLength <= 1))
                {
                    IsMultipleLabel.IsVisible = true;
                }
                if ((pipeDiameter == 4 && pipeLength == 3) || (pipeDiameter == 5 && pipeLength >= 2) || (pipeDiameter == 6 && pipeLength == 1) || (pipeDiameter == 6 && pipeLength == 2))
                {
                    sizeList.Remove("OneWhole");
                    sizeList.Add("TwoWhole");
                }
                else if (pipeDiameter == 6 && pipeLength == 3)
                {
                    sizeList.Remove("OneWhole");
                    sizeList.Add("ThreeWhole");
                }
            }
            else if (linePressure == 1)
            {
                if ((pipeDiameter == 1 && pipeLength == 3) || (pipeDiameter == 2 && pipeLength == 2) || (pipeDiameter == 3 && pipeLength == 1) || (pipeDiameter == 4 && pipeLength == 1) || (pipeDiameter == 4 && pipeLength == 3) || (pipeDiameter == 5 && pipeLength == 2) || (pipeDiameter == 6 & pipeLength == 1))
                {
                    IsMultipleLabel.IsVisible = true;
                }
                if ((pipeDiameter == 2 && pipeLength == 3) || (pipeDiameter == 3 && pipeLength >= 2) || (pipeDiameter == 4 && pipeLength >= 2) || (pipeDiameter == 5 && pipeLength <=2) || (pipeDiameter == 6 && pipeLength <= 1))
                {
                    sizeList.Remove("OneWhole");
                    sizeList.Add("TwoWhole");
                }
                else if (pipeDiameter == 6 && pipeLength == 2)
                {
                    sizeList.Remove("OneWhole");
                    sizeList.Add("ThreeWhole");
                }
                else if (pipeDiameter == 6 && pipeLength == 3)
                {
                    IsMultipleLabel.IsVisible = true;
                    sizeList.Remove("OneWhole");
                    sizeList.Add("TwoWhole");
                    sizeList.Add("ThreeWhole");
                }
            }
            GetProduct(sizeList, _bodyMaterial, _sealMaterial);
        } // End of Main Method

        async Task GetProduct(List<string> sizeArray, string _bodyMaterial, string _sealMaterial)
        {
            IsBusy = true;
            Product = new ObservableRangeCollection<Product>();
            foreach (var valveSize in sizeArray)
            {
                var products = await InternetProductService.GetPDS(valveSize, _bodyMaterial, _sealMaterial);
                Product.AddRange(products);
            }
            IsBusy = false;
        }
        private async void OnTapped(object sender, EventArgs e)
        {
            var button = (StackLayout)sender;
            var url = "https://www.plastomatic.com/products/product/" + button.ClassId;
            await Browser.OpenAsync(url);
        }
    }
}