using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Reactive.Linq;

namespace Calendar.ViewModels;

public class CalendarViewModel : ReactiveObject
{
    [Reactive] public int Year { get; set; }
    [Reactive] public int Month { get; set; }
    public DateTimeOffset CurrentDate { [ObservableAsProperty] get; }
    public CalendarMonthViewModel MonthViewModel { [ObservableAsProperty]get; }

    public ReactiveCommand<int , Unit> ChangeMonth { get; }


    public CalendarViewModel() : this( new CalendarFactory() )
    {
    }

    public CalendarViewModel( CalendarFactory calendarFactory )
    {
        MonthViewModel = new();
        Year = DateTime.Today.Year;
        Month = DateTime.Today.Month;
        
        ChangeMonth = ReactiveCommand.Create( ( int i ) =>
        {
            var date = CurrentDate.AddMonths( i );
            Month = date.Month;
            Year = date.Year;
        } );

        this.WhenAnyValue( x => x.Year , x => x.Month )
            .Throttle( TimeSpan.FromMilliseconds( 50 ) )
            .Where( t => t is { Item1: > 0 , Item2: > 0 and <= 12 } )
            .Do( t =>
            {
                Observable.Return( calendarFactory.BuildCalendarMonth( t.Item1 , t.Item2 ) )
                    .ToPropertyEx( this ,x=>x.MonthViewModel, scheduler:RxApp.MainThreadScheduler);
            } )
            .Select( t => new DateTimeOffset( t.Item1 , t.Item2 , 1 , 0 , 0 , 0 , TimeSpan.Zero ) )
            .ToPropertyEx( this , x => x.CurrentDate , scheduler: RxApp.MainThreadScheduler );
    }
}