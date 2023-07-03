using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator.Views
{
    public partial class MainMenu : ContentPage
    {

        public MainMenu()
        {
            InitializeComponent();
        }

        async void StartPressureRegulator(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PressureRegulator1));
        }
    }
}