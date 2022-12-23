namespace tripshare.tests;

public class HomePageModelsTests : IClassFixture<TripsInitialStateFixture>
{
    readonly TripsInitialStateFixture _stateFixture;

    public HomePageModelsTests(TripsInitialStateFixture stateFixture)
    {
        _stateFixture = stateFixture;
    }

    [Fact]
    public void ShouldInitializeTripsCollectionAtInstantiation()
    {
        // Arrange
        var mockIReadData = new Mock<IReadData>();
        mockIReadData
            .Setup(
            instance => instance.LoadDataAsync(It.IsAny<string>()).Result
            )
            .Returns(_stateFixture.Trips);

        // Act
        var viewModel = new HomePageModel(mockIReadData.Object);

        // Assert
        mockIReadData.Verify(
            instance => instance.LoadDataAsync("tripshare.assets.trips.json"),
            Times.Once());
        viewModel.Trips.Should().HaveCount(4);
    }
}

