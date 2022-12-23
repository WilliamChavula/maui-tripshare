namespace tripshare.tests;

public class ReadDataFromLocalFileSourceTests
{
    public ReadDataFromLocalFileSourceTests()
    {
    }

    [Fact]
    public async void ShouldCorrectlyDeserializeJsonData()
    {
        // Arrange
        var data = await StringReader();
        var source = "tripshare.tests.fixtures.trips.json";

        var mockReadData = new Mock<IFetchDataClient<string>>();
        mockReadData.Setup(instance =>
        instance.FetchDataAsync(It.IsAny<string>()).Result)
            .Returns(data);

        // Act
        var readDataCls = new ReadDataFromLocalFileSource(mockReadData.Object);
        var trips = await readDataCls.LoadDataAsync(source);

        // Assert
        mockReadData.Verify(instance =>
        instance.FetchDataAsync(source), Times.Once());

        trips.Should().NotBeEmpty()
            .And.HaveCount(3)
            .And.ContainItemsAssignableTo<Trip>();
    }

    static Task<string> StringReader()
    {
        var source = "tripshare.tests.fixtures.trips.json";
        var assembly = typeof(ReadDataFromLocalFileSourceTests).GetTypeInfo().Assembly;
        var stream = assembly.GetManifestResourceStream(source);

        using var reader = new StreamReader(stream!);
        return reader.ReadToEndAsync();
    }
}

