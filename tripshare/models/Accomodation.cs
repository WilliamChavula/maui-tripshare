namespace tripshare.models;

public enum AccommodationType
{
    Hotel, Apartment, Camping, Villa, Safari, RoadTrip
}

public class Accommodation
{
    public AccommodationType AccommodationType { get; set; }
    public string Image { get; set; }
}