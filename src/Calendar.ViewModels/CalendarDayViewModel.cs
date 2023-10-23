using LanguageExt;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Calendar.ViewModels;

public class CalendarDayViewModel : ReactiveObject
{
    public Option<DateTimeOffset> Day { get; private set; }
    public bool IsSelectable { get; init; } = true;
    public Seq<CalendarEvent> Events { get; private set; }
    [Reactive] public bool IsSelected { get; set; }

    internal CalendarDayViewModel()
    {
        Day = Option<DateTimeOffset>.None;
        Events = Seq<CalendarEvent>.Empty;
    }

    internal CalendarDayViewModel(DateTimeOffset day )
        : this(day, Seq<CalendarEvent>.Empty)
    {
    }

    internal CalendarDayViewModel( DateTimeOffset day , Seq<CalendarEvent> events  )
    {
        Day = day;
        Events = events;
    }
}