﻿// ReSharper disable AsyncVoidLambda

using Bogus;

namespace tripshare.pagemodels;

public class HomePageModel : FreshBasePageModel
{
    private readonly IReadData _readData;
    private readonly IGetAccommodations _getAccommodations;
    private readonly IDestinationService _destinationService;

    public HomePageModel(IReadData readData, IGetAccommodations getAccommodations, IDestinationService destinationService)
    {
        _getAccommodations = getAccommodations;
        _readData = readData;
        _destinationService = destinationService;
    }

    public string UserName => new Faker().Name.FirstName();
    public ObservableCollection<Trip> Trips { get; private set; }
    public ObservableCollection<Accommodation> Accommodations { get; private set; }

    public ObservableCollection<Destination> Destinations { get; private set; }
    public ObservableCollection<Promotion> Promotions { get; private set; }

    public Command NavigateToAddTripScreenCommand => new(async () =>
    {
        await CoreMethods.PushPageModel<NotificationPageModel>(
            new object(),
            modal: true
            );
    });

    public Command<Destination> GoToDetailPageCommand => new(
        async (destination) =>
        {
            await CoreMethods.PushPageModel<TripDetailPageModel>(destination);
        });

    public Command<Accommodation> NavigateToFilteredDestinationPageCommand => new(
        async (accommodation) =>
        {
            await CoreMethods.PushPageModel<FilteredDestinationPageModel>(accommodation.AccommodationType);
        });


    public override async void Init(object initData)
    {
        await LoadTrips();
        await LoadAccommodations();
        await LoadDestinations();
        LoadPromotions();
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

    private async Task LoadDestinations()
    {
        var destinations = await _destinationService.LoadDestinationsAsync();
        Destinations = new ObservableCollection<Destination>(destinations);
    }

    private async Task LoadAccommodations()
    {
        Accommodations = await _getAccommodations.LoadAccommodationsAsync();
    }

    private async Task LoadTrips()
    {
        const string source = "tripshare.assets.trips.json";
        var trips = await _readData.LoadDataAsync(source);

        if (trips is null) return;
        Trips = new ObservableCollection<Trip>();

        foreach (var trip in trips)
            Trips.Add(trip);
    }
}