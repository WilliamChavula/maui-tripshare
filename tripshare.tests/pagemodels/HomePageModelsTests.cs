using tripshare.tests.fixtures;

namespace tripshare.tests;

public class HomePageModelsTests : IClassFixture<TripsInitialStateFixture>, IClassFixture<DestinationsFixture>
{
    private readonly TripsInitialStateFixture _stateFixture;
    private readonly DestinationsFixture _destinationsFixture;

    private readonly Mock<IReadData> mockIReadData;
    private readonly Mock<IGetAccommodations> accommodations;
    private readonly Mock<IDestinationService> destinations;


    public HomePageModelsTests(TripsInitialStateFixture stateFixture, DestinationsFixture destinationsFixture)
    {
        _stateFixture = stateFixture;
        _destinationsFixture = destinationsFixture;
        mockIReadData = new Mock<IReadData>();
        accommodations = new Mock<IGetAccommodations>();
        destinations = new Mock<IDestinationService>();

        // Arrange
        mockIReadData
            .Setup(
                instance => instance.LoadDataAsync(It.IsAny<string>()).Result
            )
            .Returns(_stateFixture.Trips);

        var accommodationsFixture = new ObservableCollection<Accommodation>
        {
            new Accommodation
            {
                AccommodationType = AccommodationType.Hotel,
                Image = "test_hotel.png"
            },
            new Accommodation
            {
                AccommodationType = AccommodationType.Apartment,
                Image = "test_apartment.png"
            }
        };
        accommodations
            .Setup(
                instance => instance.LoadAccommodationsAsync().Result
            )
            .Returns(accommodationsFixture);

        destinations
            .Setup(
                instance => instance.LoadDestinationsAsync().Result
            )
            .Returns(_destinationsFixture.Destinations);
    }

    [Fact]
    public void ShouldInitializeTripsCollectionAtInstantiation()
    {
        // Act
        var viewModel = new HomePageModel(mockIReadData.Object, accommodations.Object, destinations.Object);
        viewModel.Init(new object());

        // Assert
        mockIReadData.Verify(
            instance => instance.LoadDataAsync("tripshare.assets.trips.json"),
            Times.Once());
        viewModel.Trips.Should().HaveCount(4);
    }

    [Fact]
    public void ShouldInitializeAccommodationsCollectionAtInstantiation()
    {
        // Act
        var viewModel = new HomePageModel(mockIReadData.Object, accommodations.Object, destinations.Object);
        viewModel.Init(new object());

        // Assert
        accommodations.Verify(
            instance => instance.LoadAccommodationsAsync(),
            Times.Once());

        viewModel.Accommodations
            .Should()
            .NotBeEmpty()
            .And.HaveCount(2)
            .And.AllBeOfType<Accommodation>();
    }

    [Fact]
    public void ShouldInitializeDestinationCollectionAtInstantiation()
    {
        // Act
        var viewModel = new HomePageModel(mockIReadData.Object, accommodations.Object, destinations.Object);
        viewModel.Init(new object());

        // Assert
        destinations.Verify(
            instance => instance.LoadDestinationsAsync(),
            Times.Once());
        viewModel.Destinations.Should().HaveCount(10);
    }

    [Fact]
    public void ShouldInitializePromotionsCollectionAtInstantiation()
    {
        // Act
        var viewModel = new HomePageModel(mockIReadData.Object, accommodations.Object, destinations.Object);
        viewModel.Init(new object());

        // Assert
        viewModel.Promotions.Should()
            .NotBeNullOrEmpty()
            .And.HaveCountGreaterThanOrEqualTo(1);
    }
}

