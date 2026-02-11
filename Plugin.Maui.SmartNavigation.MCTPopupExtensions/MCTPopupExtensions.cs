using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.SmartNavigation.Extensions;

namespace Plugin.Maui.SmartNavigation;

public static class MCTPopupExtensions
{
    public static async Task<IPopupResult> PushAsync<T>(this IPopupService _, IPopupOptions? options, params object[] parameters) where T : Popup
    {
        var popup = NavigationExtensions.ResolvePage<T>(parameters) as Popup
            ?? throw new ArgumentException("Could not resolve popup page");

        return await popup.Navigation.ShowPopupAsync(popup, options);
    }
}
