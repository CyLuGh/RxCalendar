namespace Calendar.ViewModels;

public record CalendarEvent
{
    public required string Description { get; init; }
    public required string Title { get; init; }
    public required string Category { get; init; }
}