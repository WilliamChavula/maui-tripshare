namespace tripshare.tests.pagemodels;

[Collection("Destinations Collection")]
public class FilteredDestinationPageModelTests
{
    private readonly Mock<IFilterDestinations> filterDestinations;
    private readonly DestinationsFixture _destinationsFixture;

    public FilteredDestinationPageModelTests(DestinationsFixture destinationsFixture)
    {
        _destinationsFixture = destinationsFixture;
        filterDestinations = new Mock<IFilterDestinations>();
    }

    [Fact]
    public void ShouldCallFilterByAccommodationTypeOnInitialization()
    {
        // Arrange
        filterDestinations.Setup(
            instance => instance.ByAccommodationType(It.IsAny<string>()).Result)
            .Returns(_destinationsFixture.Destinations);

        // Act
        var testType = new Faker().Parse("{{lorem.word()}}");
        var sut = new FilteredDestinationPageModel(filterDestinations.Object);
        sut.Init(testType);

        filterDestinations.Verify(
            instance => instance.ByAccommodationType(testType),
            Times.Once());
    }

    [Fact]
    public void ShouldHaveEmptyFilteredDestinations()
    {
        // Arrange
        filterDestinations.Setup(
            instance => instance.ByAccommodationType(It.IsAny<string>()).Result)
            .Returns(new List<Destination>());

        // Act
        var testType = new Faker().Parse("{{lorem.word()}}");
        var sut = new FilteredDestinationPageModel(filterDestinations.Object);
        sut.Init(testType);

        filterDestinations.Verify(
            instance => instance.ByAccommodationType(testType),
            Times.Once());
        sut.AccommodationType.Should().Be("No");
        sut.FilteredDestinations.Should().BeEmpty();
    }

    [Fact]
    public void ShouldPopulatedFilteredDestinations()
    {
        // Arrange
        filterDestinations.Setup(
            instance => instance.ByAccommodationType(It.IsAny<string>()).Result)
            .Returns(_destinationsFixture.Destinations);

        // Act
        var testType = new Faker().Parse("{{lorem.word()}}");
        var sut = new FilteredDestinationPageModel(filterDestinations.Object);
        sut.Init(testType);

        filterDestinations.Verify(
            instance => instance.ByAccommodationType(testType),
            Times.Once());
        sut.FilteredDestinations
            .Should()
            .NotBeEmpty()
            .And.AllBeOfType<Destination>();
        sut.AccommodationType.Should().Be(testType);
    }
}

