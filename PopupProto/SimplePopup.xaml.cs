using CommunityToolkit.Maui.Views;

namespace PopupTestApp;

public partial class SimplePopup : Popup
{
    public SimplePopup()
    {
        InitializeComponent();
    }

    private void OnCloseClicked(object? sender, EventArgs e)
    {
        this.CloseAsync();
    }
}