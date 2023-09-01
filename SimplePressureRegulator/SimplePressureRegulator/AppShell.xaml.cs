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
        }
    }
}