using FreshMvvm.Maui.Extensions;
using Microsoft.Maui.LifecycleEvents;
using tripshare.extensions;

namespace tripshare;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                //Custom Fonts
                fonts.AddFont("Oxygen-Bold.ttf", "OxygenBold");
                fonts.AddFont("Oxygen-Light.ttf", "OxygenLight");
                fonts.AddFont("Oxygen-Regular.ttf", "OxygenRegular");
                fonts.AddFont("fa-regular-400.ttf", "FaRegular");
                fonts.AddFont("fa-solid-900.ttf", "FaSolid");
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "MUIconsOutlined");
            }).ConfigureTripShareServices()
            .ConfigureEffects(effects =>
            {
#if __ANDROID__
                effects.Add<EntryBackgroundTintEffect, AndroidEntryNoBackgroundTintEffect>();
#elif IOS
                effects.Add<EntryBackgroundTintEffect, IosEntryNoBackgroundTintEffect>();
#endif

            });


        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HomePageModel>();

        builder.Services.AddTransient<AddTripPage>();
        builder.Services.AddTransient<AddTripPageModel>();

        builder.Services.AddTransient<TripDetailPage>();
        builder.Services.AddTransient<TripDetailPageModel>();

        var mauiApp = builder.Build();
        mauiApp.UseFreshMvvm();
        return mauiApp;
    }
}

