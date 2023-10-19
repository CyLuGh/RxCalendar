using LanguageExt;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Calendar.ViewModels;

public class CalendarDay : ReactiveObject
{
    public Option<DateTimeOffset> Day { get; private set; }
    [Reactive] public bool IsSelected { get; set; }

    internal CalendarDay()
    {
        Day = Option<DateTimeOffset>.None;
    }

    internal CalendarDay(DateTimeOffset day)
    {
        Day = day;
    }
}