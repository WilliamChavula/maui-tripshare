namespace tripshare.interfaces;

public interface IDestinationService
{
    Task<List<Destination>> LoadDestinationsAsync();
}

