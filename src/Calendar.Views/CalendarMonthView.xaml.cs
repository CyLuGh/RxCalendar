using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Controls;
using Calendar.ViewModels;
using ReactiveUI;

namespace Calendar.Views;

public partial class CalendarMonthView
{
    public CalendarMonthView()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            this.WhenAnyValue(x => x.ViewModel)
                .WhereNotNull()
                .Do(vm => PopulateFromViewModel(this, vm, disposables))
                .Subscribe()
                .DisposeWith(disposables);
        });
    }

    private static void PopulateFromViewModel(CalendarMonthView view, CalendarMonth viewModel,
        CompositeDisposable disposables)
    {
        
    }
}