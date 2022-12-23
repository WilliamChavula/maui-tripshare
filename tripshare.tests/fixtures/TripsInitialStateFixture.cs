namespace tripshare.tests;

public class TripsInitialStateFixture
{
    public List<Trip> Trips { get; private set; }
    public TripsInitialStateFixture()
    {
        Trips = new()
            {
                new ()
                {
                    Id = new Guid("e9adc5e8-8293-4e3f-b623-3c4bbebf0162"),
                    Date = DateOnly.Parse("4/24/2022"),
                    Latitude = 19.3376878,
                    Longitude = -99.0591821,
                    Rating = 9,
                    Notes = "Down-sized directional service-desk",
                    Title = "Open-source actuating support"
                },
                new()
                {
                    Id = new Guid("ca1c5811-8cc0-403b-9cb8-32978ce3d487"),
                    Longitude = 20.5870955,
                    Latitude = -4.3253802,
                    Date = DateOnly.Parse("12/21/2021"),
                    Rating = 8,
                    Notes = "Virtual client-driven functionalities",
                    Title = "Devolved non-volatile orchestration"
                },
                new()
                {
                    Id = new Guid("51a68e61-2e0c-40bc-9ff5-df3bcb21b99d"),
                    Longitude = 17.9738035,
                    Latitude = 49.936089,
                    Date = DateOnly.Parse("1/12/2022"),
                    Rating = 1,
                    Notes = "Sharable regional matrices",
                    Title = "Diverse eco-centric capacity"
                },
                new()
                {
                    Id = new Guid("fc617488-b1cf-4099-bb9f-0931c9954e40"),
                    Longitude = 26.8687946,
                    Latitude = 59.4520561,
                    Date = DateOnly.Parse("12/25/2021"),
                    Rating = 8,
                    Notes = "Future-proofed attitude-oriented encoding",
                    Title = "Multi-lateral interactive application"
                }
            };
    }
}

