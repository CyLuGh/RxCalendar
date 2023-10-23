using Calendar.ViewModels;
using Calendar.Views;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
//            Locator.CurrentMutable.Register( () => new CalendarDayView(), typeof(IViewFor<CalendarDayViewModel>));
            Locator.CurrentMutable.Register( () => new CalendarDayToggleView(), typeof(IViewFor<CalendarDayViewModel>));

        }
    }
}