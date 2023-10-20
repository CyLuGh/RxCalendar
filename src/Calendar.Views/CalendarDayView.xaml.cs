using Calendar.ViewModels;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Calendar.Views;

public partial class CalendarDayView
{
    public CalendarDayView()
    {
        InitializeComponent();

        this.WhenActivated( disposables =>
        {
            this.WhenAnyValue( x => x.ViewModel )
                .WhereNotNull()
                .Do( vm => PopulateFromViewModel( this , vm , disposables ) )
                .Subscribe()
                .DisposeWith( disposables );
        } );
    }

    private static void PopulateFromViewModel( CalendarDayView view , CalendarDayViewModel viewModel ,
        CompositeDisposable disposables )
    {
        view.OneWayBind( viewModel ,
                vm => vm.Day ,
                v => v.GridOuter.Visibility ,
                o => o.IsSome ? Visibility.Visible : Visibility.Collapsed )
            .DisposeWith( disposables );
    }
}