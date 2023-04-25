using System.Linq;

namespace tripshare.services;

public class FilterDestinations : IFilterDestinations
{
    private readonly IDestinationService _destinationService;

    public FilterDestinations(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    public async Task<IEnumerable<Destination>> ByAccommodationType(string accommodationType)
    {
        var allDestinations = await _destinationService.LoadDestinationsAsync();

        var isFound = Enum.TryParse(accommodationType, out AccommodationType result);

        if (!isFound)
            return new List<Destination>();

        return allDestinations.
            Where(destination => destination.AccommodationTypes.
            Contains(result));
    }
}

