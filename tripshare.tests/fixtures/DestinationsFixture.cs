namespace tripshare.tests.fixtures;

public class DestinationsFixture
{
    public List<Destination> Destinations { get; private set; }

    private List<FacilityType> facilityTypes = new() { FacilityType.Wifi, FacilityType.Lodging, FacilityType.Dining };
    private List<AccommodationType> accommodationTypes = new()
        {
            AccommodationType.Hotel,
            AccommodationType.Apartment,
            AccommodationType.Camping,
            AccommodationType.Villa
        };

    public DestinationsFixture()
    {
        Destinations = GenerateDestinations();

    }

    private List<Destination> GenerateDestinations()
    {
        var facilities = new Faker<Facility>()
            .StrictMode(true)
            .RuleFor(d => d.Image, f => f.Image.PicsumUrl())
            .RuleFor(d => d.FacilityType, f => f.PickRandom(facilityTypes))
            .Generate(5).ToList();


        var destinations = new Faker<Destination>()
            .StrictMode(true)
            .RuleFor(d => d.IsFavorite, f => f.Random.Bool())
            .RuleFor(d => d.Name, f => f.Random.Word())
            .RuleFor(d => d.Description, f => f.Lorem.Sentence())
            .RuleFor(d => d.Address, f => f.Address.StreetAddress())
            .RuleFor(d => d.Cost, f => f.Random.Double(min: 50, max: 500))
            .RuleFor(d => d.Rating, f => f.Random.Double(min: 1, max: 5))
            .RuleFor(d => d.ImageUrl, f => f.Image.PlaceImgUrl())
            .RuleFor(d => d.AccommodationTypes, f => f.PickRandom(accommodationTypes, 3).ToList())
            .RuleFor(d => d.Facilities, f => facilities)
            .Generate(10);

        return destinations;
    }
}

[CollectionDefinition("Destinations Collection")]
public class DestinationsCollection : ICollectionFixture<DestinationsFixture> { }

