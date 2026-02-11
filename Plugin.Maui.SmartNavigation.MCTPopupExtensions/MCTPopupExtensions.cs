using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.SmartNavigation.Extensions;
using Plugin.Maui.SmartNavigation.Services;

namespace Plugin.Maui.SmartNavigation;

public static class MCTPopupExtensions
{
    public static async Task PushAsync<T>(this IPopupService navigation) where T: Popup
    {
        var popup = Resolver.Resolve<T>() as Popup
            ?? throw new ArgumentException("Could not resolve popup page");

        await navigation.PushAsync(popup, true);
    }

    public static async Task PushAsync<T>(this IPopupService navigation, params object[] parameters) where T : Popup
    {
        var popup = NavigationExtensions.ResolvePage<T>(parameters) as Popup
            ?? throw new ArgumentException("Could not resolve popup page");

        await navigation.PushAsync(popup, true);
    }
}
