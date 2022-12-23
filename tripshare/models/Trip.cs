namespace tripshare.models;

public class Trip
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateOnly Date { get; set; }
    public int Rating { get; set; }
    public string Notes { get; set; }
}

