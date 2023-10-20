using LanguageExt;

namespace Calendar.ViewModels;

public class CalendarMonthViewModel
{
    public Seq<CalendarDayViewModel> Days { get; internal init; }
}