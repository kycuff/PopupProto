using CommunityToolkit.Maui.Core;
using PopupProto.Features;
using PopupTestApp;

namespace PopupProto
{
    public partial class MainPage : ContentPage
    {
        private readonly INavigationPopupFeature _popupNavigation;

        public MainPage(INavigationPopupFeature popupNavigation)
        {
            InitializeComponent();
            _popupNavigation = popupNavigation;
        }

        private async void OnSimpleButtonClicked(object sender, EventArgs e)
        {
            // Use the navigation popup feature
            IPopupResult result = await _popupNavigation.PushAsync<SimplePopup>();

            if(result is IPopupResult message)
            {
                await DisplayAlertAsync("Result", message.ToString(), "OK");
            }
        }
    }
}
