using CommunityToolkit.Maui.Core;
using PopupProto.Features;
using PopupTestApp;

namespace PopupProto
{
    public partial class MainPage : ContentPage
    {
        private readonly INavigationPopupFeature _popupNavigation;
        int count = 0;

        public MainPage(INavigationPopupFeature popupNavigation)
        {
            InitializeComponent();
            _popupNavigation = popupNavigation;
        }

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if(count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            // Use the navigation popup feature
            IPopupResult result = await _popupNavigation.PushAsync<SimplePopup>();

            if(result is IPopupResult message)
            {
                await DisplayAlertAsync("Result", message.ToString(), "OK");
            }
        }
    }
}
