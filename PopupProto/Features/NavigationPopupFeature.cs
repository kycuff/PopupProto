using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

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

    public Task<IPopupResult> ShowPopupAsync<T>(IPopupOptions? options = null, CancellationToken cancellationToken = default) where T : notnull
    {
        return _popupService.ShowPopupAsync<T>(Navigation, options, cancellationToken);
    }

    public Task<IPopupResult<TResult>> ShowPopupAsync<T, TResult>(IPopupOptions? options = null, CancellationToken cancellationToken = default) where T : notnull
    {
        return _popupService.ShowPopupAsync<T, TResult>(Navigation, options, cancellationToken);
    }
}
