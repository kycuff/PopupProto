using CommunityToolkit.Maui.Views;

namespace PopupTestApp;

public partial class SimplePopup : Popup
{
    public SimplePopup()
    {
        InitializeComponent();
    }

    private async void OnCloseClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
    }
}