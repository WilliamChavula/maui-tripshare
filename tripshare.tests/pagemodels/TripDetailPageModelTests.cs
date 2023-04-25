namespace tripshare.tests.pagemodels;

[Collection("Destinations Collection")]
public class TripDetailPageModelTests
{
    private readonly DestinationsFixture _destinationsFixture;

    public TripDetailPageModelTests(DestinationsFixture destinationsFixture)
    {
        _destinationsFixture = destinationsFixture;
    }

    [Fact]
    public void ShouldPopulatedDestinationPropertyOnInit()
    {
        // Arrange
        var destination = _destinationsFixture.Destinations.FirstOrDefault();
        var sut = new TripDetailPageModel();

        // Act
        sut.Init(destination);

        // Assert
        sut.Destination
            .Should()
            .NotBeNull()
            .And.BeOfType<Destination>()
            .And.BeEquivalentTo(destination);
    }
}

