using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Reactive.Linq;

namespace Calendar.ViewModels;

public class CalendarMonthViewModel : IActivatableViewModel
{
    public Seq<CalendarDayViewModel> Days { get; }
    public IObservable<(DateTimeOffset , bool)> SelectionsChanges { get; }

    public CalendarMonthViewModel( Seq<CalendarDayViewModel> days )
    {
        Activator = new();
        Days = days;

        SelectionsChanges = Days.Where( d => d.Day.IsSome )
            .Map( d => d.WhenAnyValue( x => x.IsSelected ).Select( b => ( d.Day.ValueUnsafe() , b ) ) )
            .Merge();
        
    }

    public ViewModelActivator Activator { get; }
}