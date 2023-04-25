namespace tripshare.interfaces;

public interface IFilterDestinations
{
    Task<IEnumerable<Destination>> ByAccommodationType(string accommodationType);
}

