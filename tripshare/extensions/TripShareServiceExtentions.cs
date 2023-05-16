using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;

namespace tripshare.extensions;

public static class TripShareServiceExtentions
{
    public static MauiAppBuilder ConfigureTripShareServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IFetchDataClient<string>, FetchFromJsonFile>();
        builder.Services.AddSingleton<IReadData, ReadDataFromLocalFileSource>();
        builder.Services.AddSingleton<IGetAccommodations, GetAccommodations>();
        builder.Services.AddSingleton<IDestinationService, DestinationService>();
        builder.Services.AddSingleton<IFilterDestinations, FilterDestinations>();
        builder.Services.AddSingleton<INotificationService, NotificationService>();

        return builder;
    }
}

