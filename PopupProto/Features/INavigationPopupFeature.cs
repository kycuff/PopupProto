using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopupProto.Features;

public interface INavigationPopupFeature
{
    Task<IPopupResult> ShowPopupAsync<T>(IPopupOptions? options = null, CancellationToken cancellationToken = default) where T : notnull;
    Task<IPopupResult<TResult>> ShowPopupAsync<T, TResult>(IPopupOptions? options = null, CancellationToken cancellationToken = default) where T : notnull;
}
