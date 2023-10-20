using LanguageExt;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Calendar.ViewModels;

public class CalendarDayViewModel : ReactiveObject
{
    public Option<DateTimeOffset> Day { get; private set; }
    [Reactive] public bool IsSelected { get; set; }

    internal CalendarDayViewModel()
    {
        Day = Option<DateTimeOffset>.None;
    }

    internal CalendarDayViewModel(DateTimeOffset day)
    {
        Day = day;
    }
}