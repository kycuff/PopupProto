using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;

namespace PopupProto.Features;

public interface INavigationPopupFeature
{
    Task<IPopupResult> ShowPopupAsync<T>(IPopupOptions? options = null, CancellationToken cancellationToken = default) where T : notnull;
    Task<IPopupResult<TResult>> ShowPopupAsync<T, TResult>(IPopupOptions? options = null, CancellationToken cancellationToken = default) where T : notnull;
}
