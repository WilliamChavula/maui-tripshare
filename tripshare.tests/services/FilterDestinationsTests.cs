namespace tripshare.tests.services;

[Collection("Destinations Collection")]
public class FilterDestinationsTests
{
    private readonly DestinationsFixture _destinationsFixture;
    private readonly Mock<IDestinationService> destinations;

    public FilterDestinationsTests(DestinationsFixture destinationsFixture)
    {
        _destinationsFixture = destinationsFixture;
        destinations = new Mock<IDestinationService>();

        // Arrange
        destinations
            .Setup(instance => instance.LoadDestinationsAsync().Result)
            .Returns(_destinationsFixture.Destinations);
    }

    [Fact]
    public async void ShouldCallLoadDestinationsMethodWhenFilterByAccommodationIsInvoked()
    {
        // Act
        var type = AccommodationType.Hotel;
        var sut = new FilterDestinations(destinations.Object);
        var filtered_results = await sut.ByAccommodationType(type.ToString());

        // Assert
        destinations.Verify(
            instance => instance.LoadDestinationsAsync(),
            Times.Once());
    }

    [Fact]
    public async void ShouldFilterDestinationsByAccommodationTypeAndReturnNonEmptyResult()
    {
        // Act
        var type = AccommodationType.Hotel;
        var sut = new FilterDestinations(destinations.Object);
        var filtered_results = await sut.ByAccommodationType(type.ToString());

        // Assert
        filtered_results
            .Should()
            .NotBeNull()
            .And
            .HaveCountLessThanOrEqualTo(_destinationsFixture.Destinations.Count)
            .And
            .AllSatisfy(fr => fr.AccommodationTypes.Should().Contain(type));
    }

    [Fact]
    public async void ShouldFilterDestinationsByAccommodationTypeAndReturnEmptyResult()
    {
        // Arrange
        var faker = new Faker();
        var randomWord = faker.Parse("{{lorem.word()}}");

        // Act
        var sut = new FilterDestinations(destinations.Object);
        var filtered_results = await sut.ByAccommodationType(randomWord);

        // Assert
        filtered_results.Should().BeEmpty();
    }
}

