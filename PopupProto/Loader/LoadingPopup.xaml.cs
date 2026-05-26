using CommunityToolkit.Maui.Views;

namespace PopupProto.Loader;

public partial class LoadingPopup : Popup
{
    public LoadingPopup(string loadingText)
    {
        InitializeComponent();
        UpdateText(loadingText);
    }

    public void UpdateText(string loadingText)
    {
        LoadingLbl.Text = loadingText;
    }
}