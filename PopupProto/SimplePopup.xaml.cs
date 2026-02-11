using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;

namespace PopupTestApp;

public partial class SimplePopup : ContentPage
{
    public SimplePopup()
    {
        InitializeComponent();
    }

    private async void OnCloseClicked(object? sender, EventArgs e)
    {
        await this.ClosePopupAsync();
    }
}