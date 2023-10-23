using LanguageExt;

namespace Calendar.ViewModels;

public interface ICalendarFactory
{
    CalendarMonthViewModel BuildCalendarMonth( int year , int month );

    CalendarMonthViewModel BuildCalendarMonth( int year , int month ,
        HashMap<DateTimeOffset , Seq<CalendarEvent>> events );
}