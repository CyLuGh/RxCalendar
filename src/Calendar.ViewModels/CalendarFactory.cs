using LanguageExt;

namespace Calendar.ViewModels;

public class CalendarFactory
{
    public CalendarMonth BuildCalendarMonth(int year, int month)
    {
        var firstDay = new DateTimeOffset(new DateTime(year, month, 1), TimeSpan.Zero);
        var days = new List<CalendarDay>();

        for (var i = 1; i < (int)firstDay.DayOfWeek + (firstDay.DayOfWeek == DayOfWeek.Sunday ? 7 : 0); i++)
            days.Add(new CalendarDay());

        var daysInMonth = DateTime.DaysInMonth(year, month);

        for (int i = 0; i < daysInMonth; i++)
        {
            var day = firstDay.AddDays(i);
            days.Add(new CalendarDay(day));
        }

        return new CalendarMonth { Days = days.ToSeq() };
    }
}