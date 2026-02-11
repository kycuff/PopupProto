using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.SmartNavigation.Extensions;

namespace Plugin.Maui.SmartNavigation;

public static class MCTPopupExtensions
{
    public static Task<IPopupResult> ShowPopupAsync<T>(this IPopupService _, IPopupOptions? options, CancellationToken cancellationToken, params object[] parameters) where T : Popup
    {
        var popup = NavigationExtensions.ResolvePage<T>(parameters) as Popup
           ?? throw new ArgumentException("Could not resolve popup page");

        return popup.Navigation.ShowPopupAsync(popup, options, cancellationToken);
    }

    public static Task<IPopupResult<TResult>> ShowPopupAsync<T, TResult>(this IPopupService _, IPopupOptions? options, CancellationToken cancellationToken, params object[] parameters) where T : Popup
    {
        var popup = NavigationExtensions.ResolvePage<T>(parameters) as Popup
          ?? throw new ArgumentException("Could not resolve popup page");

        return popup.Navigation.ShowPopupAsync<TResult>(popup, options, cancellationToken);
    }
}
