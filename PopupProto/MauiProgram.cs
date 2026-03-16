using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.SmartNavigation;
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
                .UseMauiCommunityToolkit(options =>
                {
                    options.SetPopupDefaults(new DefaultPopupSettings
                    {
                        Margin = 0,
                        Padding = 0,
                        VerticalOptions = LayoutOptions.Fill,
                        HorizontalOptions = LayoutOptions.Fill,
                        BackgroundColor = Colors.Transparent,
                        //CanBeDismissedByTappingOutsideOfPopup = false
                    });
                    options.SetPopupOptionsDefaults(new DefaultPopupOptionsSettings
                    {
                        PageOverlayColor = Colors.Blue,
                        Shape = null,
                        Shadow = null
                    });
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseSmartNavigation();

            builder.Services.AddSingleton<INavigationPopupFeature, NavigationPopupFeature>();

            // Register popups
            builder.Services.AddTransient<SimplePopup>();
            builder.Services.AddTransient<MessagePopup>();
            builder.Services.AddTransient<AddPopup>();

            // Register pages
            builder.Services.AddTransient<MainPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
