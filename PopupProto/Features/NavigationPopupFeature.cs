using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.SmartNavigation;
using System.Diagnostics;

namespace PopupProto.Features;

public class NavigationPopupFeature : INavigationPopupFeature
{
    protected static INavigation Navigation
    {
        get
        {
            INavigation? navigation = Application.Current?.Windows?.FirstOrDefault()?.Page?.Navigation;


            if(navigation is not null)
            {
                return navigation;

            }
            else
            {
                if(Debugger.IsAttached)
                {
                    Debugger.Break();

                }
                throw new NullReferenceException(nameof(Navigation));

            }
        }
    }

    private readonly IPopupService _popupService;

    public NavigationPopupFeature(IPopupService popupService)
    {
        _popupService = popupService;
    }

    public Task<IPopupResult> PushAsync<T>(INavigation navigation, IPopupOptions? options, CancellationToken cancellationToken) where T : Popup
    {
        return navigation.PushAsync<T>(options, cancellationToken);
    }

    //public Task<IPopupResult<TResult>> ShowPopupAsync<T, TResult>(IPopupOptions? options, CancellationToken cancellationToken) where T : Page
    //{
    //    return _popupService.PushAsync<T, TResult>(options, cancellationToken);
    //}

    //public Task<IPopupResult> ShowPopupAsync<T>(IPopupOptions? options, CancellationToken cancellationToken, params object[] parameters) where T : Page
    //{
    //    return _popupService.PushAsync<T>(options, cancellationToken, parameters);
    //}

    //public Task<IPopupResult<TResult>> ShowPopupAsync<T, TResult>(IPopupOptions? options, CancellationToken cancellationToken, params object[] parameters) where T : Page
    //{
    //    return _popupService.PushAsync<T, TResult>(options, cancellationToken, parameters);
    //}
}
