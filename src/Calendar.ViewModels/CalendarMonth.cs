using LanguageExt;

namespace Calendar.ViewModels;

public class CalendarMonth
{
    public Seq<CalendarDay> Days { get; internal init; }
}