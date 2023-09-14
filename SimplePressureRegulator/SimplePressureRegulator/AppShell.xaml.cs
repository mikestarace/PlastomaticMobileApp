using SimplePressureRegulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimplePressureRegulator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PressureRegulator1), typeof(PressureRegulator1));
            Routing.RegisterRoute(nameof(PressureRegulator2), typeof(PressureRegulator2));
            Routing.RegisterRoute(nameof(PulsationDampener1), typeof(PulsationDampener1));
            Routing.RegisterRoute(nameof(PulsationDampener2), typeof(PulsationDampener2));
            Routing.RegisterRoute(nameof(GPMCalculator), typeof(GPMCalculator));
            Routing.RegisterRoute(nameof(GPMCalculator2), typeof(GPMCalculator2));
            Routing.RegisterRoute(nameof(CvCalculator), typeof(CvCalculator));
            Routing.RegisterRoute(nameof(CvCalculator2), typeof(CvCalculator2));
            Routing.RegisterRoute(nameof(PressureDropCalculator), typeof(PressureDropCalculator));
            Routing.RegisterRoute(nameof(PressureDropCalculator2), typeof(PressureDropCalculator2));
        }
    }
}