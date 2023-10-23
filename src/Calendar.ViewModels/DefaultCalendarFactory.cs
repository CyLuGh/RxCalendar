using LanguageExt;

namespace Calendar.ViewModels;

public class DefaultCalendarFactory : ICalendarFactory
{
    public CalendarMonthViewModel BuildCalendarMonth( int year , int month )
        => BuildCalendarMonth( year , month , HashMap<DateTimeOffset , Seq<CalendarEvent>>.Empty );

    public CalendarMonthViewModel BuildCalendarMonth( int year ,
        int month ,
        HashMap<DateTimeOffset , Seq<CalendarEvent>> events )
    {
        var firstDay = new DateTimeOffset( new DateTime( year , month , 1 ) , TimeSpan.Zero );
        var days = new List<CalendarDayViewModel>();

        for ( var i = 1 ; i < (int) firstDay.DayOfWeek + ( firstDay.DayOfWeek == DayOfWeek.Sunday ? 7 : 0 ) ; i++ )
            days.Add( new CalendarDayViewModel() );

        var daysInMonth = DateTime.DaysInMonth( year , month );

        for ( int i = 0 ; i < daysInMonth ; i++ )
        {
            var day = firstDay.AddDays( i );
            var evts = events.Find( day , s => s , () => Seq<CalendarEvent>.Empty );
            days.Add( new CalendarDayViewModel( day , evts ) );
        }

        return new CalendarMonthViewModel( days.ToSeq() );
    }
}