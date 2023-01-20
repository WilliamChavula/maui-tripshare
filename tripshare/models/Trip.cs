namespace tripshare.models;

public record Trip
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public DateOnly Date { get; init; }
    public int Rating { get; init; }
    public string Notes { get; init; }
}

