namespace tripshare.services;

public class GetAccommodations : IGetAccommodations
{
    public Task<ObservableCollection<Accommodation>> LoadAccommodationsAsync()
    {
        var accommodations = new ObservableCollection<Accommodation>
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

        return Task.FromResult(accommodations);
    }
}

