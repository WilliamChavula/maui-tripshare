namespace tripshare;

public class HomePageModel : FreshBasePageModel
{
    readonly IReadData _readData;

    public ObservableCollection<Trip> Trips { get; set; }
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

