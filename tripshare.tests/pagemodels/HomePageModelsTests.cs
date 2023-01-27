namespace tripshare.tests;

public class HomePageModelsTests : IClassFixture<TripsInitialStateFixture>
{
    private readonly TripsInitialStateFixture _stateFixture;
    private readonly Mock<IReadData> mockIReadData;
    private readonly Mock<IGetAccommodations> accommodations;


    public HomePageModelsTests(TripsInitialStateFixture stateFixture)
    {
        _stateFixture = stateFixture;
        mockIReadData = new Mock<IReadData>();
        accommodations = new Mock<IGetAccommodations>();
    }

    [Fact]
    public void ShouldInitializeTripsCollectionAtInstantiation()
    {
        // Arrange
        mockIReadData
            .Setup(
            instance => instance.LoadDataAsync(It.IsAny<string>()).Result
            )
            .Returns(_stateFixture.Trips);

        // Act
        var viewModel = new HomePageModel(mockIReadData.Object, accommodations.Object);

        // Assert
        mockIReadData.Verify(
            instance => instance.LoadDataAsync("tripshare.assets.trips.json"),
            Times.Once());
        viewModel.Trips.Should().HaveCount(4);
    }

    [Fact]
    public void ShouldInitializeAccommodationsCollectionAtInstantiation()
    {
        // Arrange
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

        // Act
        var viewModel = new HomePageModel(mockIReadData.Object, accommodations.Object);

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
}

