using LanguageExt;

namespace Calendar.ViewModels;

public class CalendarFactory
{
    public CalendarMonthViewModel BuildCalendarMonth(int year, int month)
    {
        var firstDay = new DateTimeOffset(new DateTime(year, month, 1), TimeSpan.Zero);
        var days = new List<CalendarDayViewModel>();

        for (var i = 1; i < (int)firstDay.DayOfWeek + (firstDay.DayOfWeek == DayOfWeek.Sunday ? 7 : 0); i++)
            days.Add(new CalendarDayViewModel());

        var daysInMonth = DateTime.DaysInMonth(year, month);

        for (int i = 0; i < daysInMonth; i++)
        {
            var day = firstDay.AddDays(i);
            days.Add(new CalendarDayViewModel(day));
        }

        return new CalendarMonthViewModel { Days = days.ToSeq() };
    }
}