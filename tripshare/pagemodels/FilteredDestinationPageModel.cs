namespace tripshare.pagemodels;

[AddINotifyPropertyChangedInterface]
public class FilteredDestinationPageModel : FreshBasePageModel
{
    private readonly IFilterDestinations _filterDestinations;

    public Command PopFilterPageModal => new(async () =>
    {
        await CoreMethods.PopPageModel();
    });

    public Command<Destination> GoToDetailPageCommand => new(async (destination) =>
    {
        await CoreMethods.PushPageModel<TripDetailPageModel>(destination);
    });

    public FilteredDestinationPageModel(IFilterDestinations filterDestinations)
    {
        _filterDestinations = filterDestinations;
    }

    public ObservableCollection<Destination> FilteredDestinations { get; set; }
    public string AccommodationType { get; set; }

    public override async void Init(object initData)
    {
        var accommodation = initData.ToString();
        var filteredDestinations = await _filterDestinations.ByAccommodationType(accommodation);

        if (!filteredDestinations.Any())
        {
            FilteredDestinations = new ObservableCollection<Destination>();
            AccommodationType = "No";
        }
        else
        {
            FilteredDestinations = new ObservableCollection<Destination>(filteredDestinations);
            AccommodationType = accommodation;
        }
    }
}

