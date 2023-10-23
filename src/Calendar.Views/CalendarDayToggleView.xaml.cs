using Calendar.ViewModels;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Calendar.Views;

public partial class CalendarDayToggleView
{
    public CalendarDayToggleView()
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

    private static void PopulateFromViewModel( CalendarDayToggleView view , CalendarDayViewModel viewModel ,
        CompositeDisposable disposables )
    {
        view.OneWayBind( viewModel ,
                vm => vm.Day ,
                v => v.ToggleButtonDay.Visibility ,
                o => o.IsSome ? Visibility.Visible : Visibility.Collapsed )
            .DisposeWith( disposables );
        
        view.OneWayBind( viewModel ,
                vm => vm.Day ,
                v => v.ToggleButtonDay.Content ,
                o => o.Match(d=>$"{d.Day:00}",()=>string.Empty  ) )
            .DisposeWith( disposables );

        view.Bind( viewModel ,
                vm => vm.IsSelected ,
                v => v.ToggleButtonDay.IsChecked )
            .DisposeWith( disposables );

        view.OneWayBind( viewModel ,
                vm => vm.IsSelectable ,
                v => v.IsHitTestVisible )
            .DisposeWith( disposables );
    }
}