namespace tripshare.services;

public class ReadDataFromLocalFileSource : IReadData
{
    private readonly IFetchDataClient<string> _dataClient;

    public ReadDataFromLocalFileSource(IFetchDataClient<string> dataClient)
    {
        _dataClient = dataClient;
    }

    public async Task<IEnumerable<Trip>> LoadDataAsync(string source)
    {
        var data = await _dataClient.FetchDataAsync(source);

        var options = new JsonSerializerOptions
        {
            Converters = { new CustomDateTimeConverter() }
        };

        return JsonSerializer.Deserialize<IEnumerable<Trip>>(data, options);

    }
}

internal class CustomDateTimeConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString()!, "dd/mm/yyyy", null);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
