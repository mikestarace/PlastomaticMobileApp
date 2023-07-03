using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimplePressureRegulator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void StartPressureRegulator(object sender, EventArgs e)
        {
            DisplayAlert("Testing", "it worked", "cool");
        }
    }
}
