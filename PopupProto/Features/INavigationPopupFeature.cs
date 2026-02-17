using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace PopupProto.Features;

public interface INavigationPopupFeature
{
    Task<IPopupResult> PushAsync<T>(INavigation navigation, IPopupOptions? options, CancellationToken cancellationToken) where T : Popup;
    Task<IPopupResult> PushAsync<T>(INavigation navigation, IPopupOptions? options, CancellationToken cancellationToken, params object[] parameters) where T : Popup;
    //Task<IPopupResult<TResult>> ShowPopupAsync<T, TResult>(IPopupOptions? options, CancellationToken cancellationToken) where T : Page;
    //Task<IPopupResult<TResult>> ShowPopupAsync<T, TResult>(IPopupOptions? options, CancellationToken cancellationToken, params object[] parameters) where T : Page;
}
