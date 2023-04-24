// ReSharper disable AsyncVoidLambda

namespace tripshare.pagemodels;

public class HomePageModel : FreshBasePageModel
{
    private readonly IReadData _readData;
    private readonly IGetAccommodations _getAccommodations;

    public ObservableCollection<Trip> Trips { get; private set; }
    public ObservableCollection<Accommodation> Accommodations { get; private set; }

    public ObservableCollection<Destination> Destinations { get; private set; }
    public ObservableCollection<Promotion> Promotions { get; private set; }

    public Command NavigateToAddTripScreenCommand => new(async () =>
    {
        await CoreMethods.PushPageModel<AddTripPageModel>();
    });

    public Command<Destination> GoToDetailPageCommand => new(async (destination) =>
    {
        await CoreMethods.PushPageModel<TripDetailPageModel>(destination);
    });

    public HomePageModel(IReadData readData, IGetAccommodations getAccommodations)
    {
        _getAccommodations = getAccommodations;
        _readData = readData;
    }

    public override void Init(object initData)
    {
        LoadTrips();
        LoadAccommodations();
        LoadDestinations();
        LoadPromotions();
        base.Init(initData);
    }

    private void LoadPromotions()
    {
        Promotions = new ObservableCollection<Promotion>
        {
            new()
            {
                ImageUrl = "banner_1.png"
            },
            new()
            {
                ImageUrl = "banner_2.png"
            },
            new()
            {
                ImageUrl = "banner_3.png"
            }
        };
    }

    private async void LoadDestinations()
    {
        Destinations = await DestinationService.LoadDestinationsAsync();
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