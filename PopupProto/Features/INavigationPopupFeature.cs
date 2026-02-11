using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopupProto.Features;

public interface INavigationPopupFeature
{
    Task PopAllAsync();

    Task PopAsync();

    Task RemovePopupAsync(Popup popup);

    Task<IPopupResult> PushAsync(Popup popup);

    Task<IPopupResult> PushAsync<T>() where T : Popup;

    Task<IPopupResult> PushAsync<T>(Action<T>? configure) where T : Popup;

    IReadOnlyList<Popup> NavigationStack { get; }
}
