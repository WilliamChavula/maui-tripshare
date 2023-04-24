namespace tripshare.models;

public enum FacilityType
{
    Wifi,
    Lodging,
    Dining,
    Cinema,
    Swimming,
    Hiking,
    Bar
}

public class Facility
{
    public FacilityType FacilityType { get; set; }
    public string Image { get; set; }
}

public class Destination
{
    public bool IsFavorite { get; set; }
    public double Cost { get; set; }
    public double Rating { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ImageUrl { get; set; }
    public IList<Facility> Facilities { get; set; }
    public string Description { get; set; }
}