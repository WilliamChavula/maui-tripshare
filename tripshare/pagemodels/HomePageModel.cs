namespace tripshare.pagemodels;

public class HomePageModel : FreshBasePageModel
{
    private readonly IReadData _readData;
    private readonly IGetAccommodations _getAccommodations;

    public ObservableCollection<Trip> Trips { get; private set; }
    public ObservableCollection<Accommodation> Accommodations { get; private set; }
    public Command NavigateToAddTripScreenCommand =>
        // ReSharper disable once AsyncVoidLambda
        new(async () =>
        {
            await CoreMethods.PushPageModel<AddTripPageModel>();
        });

    public HomePageModel(IReadData readData, IGetAccommodations getAccommodations)
    {
        _getAccommodations = getAccommodations;
        _readData = readData;
        LoadTrips();
        LoadAccommodations();
    }

    private async void LoadAccommodations()
    {
        Accommodations = await _getAccommodations.LoadAccommodationsAsync();
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

