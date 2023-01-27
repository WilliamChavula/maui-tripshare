namespace tripshare.interfaces;

public interface IGetAccommodations
{
    Task<ObservableCollection<Accommodation>> LoadAccommodationsAsync();
}

