using Calendar.ViewModels;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Controls;

namespace Calendar.Views;

public partial class CalendarView
{
    public CalendarView()
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

    private static void PopulateFromViewModel( CalendarView view, CalendarViewModel viewModel, CompositeDisposable disposables )
    {
        view.BindCommand( viewModel ,
                vm => vm.ChangeMonth ,
                v => v.ButtonPreviousMonth ,
                Observable.Return( -1 ) )
            .DisposeWith( disposables );
        
        view.BindCommand( viewModel ,
                vm => vm.ChangeMonth ,
                v => v.ButtonNextMonth ,
                Observable.Return( 1 ) )
            .DisposeWith( disposables );
        
        view.BindCommand( viewModel ,
                vm => vm.ChangeMonth ,
                v => v.ButtonPreviousYear ,
                Observable.Return( -12 ) )
            .DisposeWith( disposables );
        
        view.BindCommand( viewModel ,
                vm => vm.ChangeMonth ,
                v => v.ButtonNextYear ,
                Observable.Return( 12 ) )
            .DisposeWith( disposables );

        view.OneWayBind( viewModel ,
                vm => vm.CurrentDate ,
                v => v.TextBlockPeriod.Text ,
                d => $"{d.Year}/{d.Month:00}" )
            .DisposeWith( disposables );

        view.OneWayBind( viewModel ,
                vm => vm.MonthViewModel ,
                v => v.MonthView.ViewModel )
            .DisposeWith( disposables );
    }
}