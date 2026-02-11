using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PopupProto.Features;
using PopupTestApp;

namespace PopupProto
{
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
                });

            builder.Services.AddSingleton<INavigationPopupFeature, NavigationPopupFeature>();

            // Register popups
            builder.Services.AddTransient<SimplePopup>();

            // Register pages
            builder.Services.AddTransient<MainPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
