// ReSharper disable once CheckNamespace
namespace tripshare;

public class HomePageModel : FreshBasePageModel
{
    private readonly IReadData _readData;

    public ObservableCollection<Trip> Trips { get; private set; }
    public ObservableCollection<Accommodation> Accommodations { get; private set; }
    public Command NavigateToAddTripScreenCommand =>
        // ReSharper disable once AsyncVoidLambda
        new(async () =>
        {
            await CoreMethods.PushPageModel<AddTripPageModel>();
        });

    public HomePageModel(IReadData readData)
    {
        _readData = readData;
        LoadTrips();
        LoadAccommodations();
    }

    private void LoadAccommodations()
    {
        Accommodations = new ObservableCollection<Accommodation>
        {
            new Accommodation
            {
                AccommodationType = AccommodationType.Hotel,
                Image = "hotel.png"
            },
            new Accommodation
            {
                AccommodationType = AccommodationType.Apartment,
                Image = "apartment.png"
            },
            new Accommodation
            {
                AccommodationType = AccommodationType.Villa,
                Image = "villa.png"
            },
            new Accommodation
            {
                AccommodationType = AccommodationType.Camping,
                Image = "glamping.png"
            },
        };
    }

    private async void LoadTrips()
    {
        const string source = "tripshare.assets.trips.json";
        var trips = await _readData.LoadDataAsync(source);

        if (trips is null) return;
        Trips = new ObservableCollection<Trip>();

        foreach (var trip in trips)
            Trips.Add(trip);
    }
}

