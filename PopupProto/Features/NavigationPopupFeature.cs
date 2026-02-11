using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PopupProto.Features;

public class NavigationPopupFeature : INavigationPopupFeature
{
    private readonly IPopupService _popupService;
    private readonly IServiceProvider _serviceProvider;
    private readonly List<Popup> _popupStack = [];

    public NavigationPopupFeature(IPopupService popupService, IServiceProvider serviceProvider)
    {
        _popupService = popupService;
        _serviceProvider = serviceProvider;
    }

    public IReadOnlyList<Popup> NavigationStack => _popupStack.AsReadOnly();

    public async Task PopAllAsync()
    {
        while(_popupStack.Count > 0)
        {
            await PopAsync();
        }
    }

    public async Task PopAsync()
    {
        if(_popupStack.Count == 0)
            return;

        var popup = _popupStack[^1];
        _popupStack.RemoveAt(_popupStack.Count - 1);
        await popup.CloseAsync();
    }

    public async Task RemovePopupAsync(Popup popup)
    {
        if(_popupStack.Remove(popup))
        {
            await popup.CloseAsync();
        }
    }

    public async Task<IPopupResult> PushAsync(Popup popup)
    {
        _popupStack.Add(popup);

        var result = await GetCurrentPage().ShowPopupAsync(popup);

        // Remove from stack when closed
        _popupStack.Remove(popup);

        return result;
    }

    public async Task<IPopupResult> PushAsync<T>() where T : Popup
    {
        return await PushAsync<T>(configure: null);
    }

    public async Task<IPopupResult> PushAsync<T>(Action<T>? configure) where T : Popup
    {
        var popup = _serviceProvider.GetRequiredService<T>();
        configure?.Invoke(popup);

        _popupStack.Add(popup);

        var result = await GetCurrentPage().ShowPopupAsync(popup);

        // Remove from stack when closed
        _popupStack.Remove(popup);

        return result;
    }

    private static Page GetCurrentPage()
    {
        if(Application.Current?.Windows.FirstOrDefault()?.Page is Page page)
        {
            // Navigate to the current visible page
            while(page is NavigationPage navPage && navPage.CurrentPage is not null)
                page = navPage.CurrentPage;

            while(page is Shell shell && shell.CurrentPage is not null)
                page = shell.CurrentPage;

            while(page is TabbedPage tabbedPage && tabbedPage.CurrentPage is not null)
                page = tabbedPage.CurrentPage;

            return page;
        }

        throw new InvalidOperationException("Unable to find the current page.");
    }
}
