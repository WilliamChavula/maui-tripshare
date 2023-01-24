using FreshMvvm.Maui.Extensions;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

using tripshare.extensions;

namespace tripshare;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
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
            }).ConfigureTripShareServices();


        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HomePageModel>();

        builder.Services.AddTransient<AddTripPage>();
        builder.Services.AddTransient<AddTripPageModel>();

        var mauiApp = builder.Build();
        mauiApp.UseFreshMvvm();
        return mauiApp;
    }
}

