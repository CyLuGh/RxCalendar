using Calendar.ViewModels;
using Calendar.Views;
using System.Windows;

namespace DemoWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var factory = new DefaultCalendarFactory();
            
            CalendarView.ViewModel = new CalendarViewModel( factory );
            CalendarViewMaterial.ViewModel = new CalendarViewModel( factory );
        }
    }
}