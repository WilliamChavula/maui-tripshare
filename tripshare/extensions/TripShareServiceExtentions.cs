namespace tripshare.extensions;

public static class TripShareServiceExtentions
{
    public static MauiAppBuilder ConfigureTripShareServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IFetchDataClient<string>, FetchFromJsonFile>();
        builder.Services.AddSingleton<IReadData, ReadDataFromLocalFileSource>();

        return builder;
    }
}

