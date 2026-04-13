using CommunityToolkit.Maui.Core;
using PopupProto.Features;
using PopupProto.Loader;
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
            try
            {
                // Use the navigation popup feature
                IPopupResult result = await _popupNavigation.PushAsync<SimplePopup>(this.Navigation, null, CancellationToken.None);

                if(result is IPopupResult message)
                {
                    await DisplayAlertAsync("Result", message.ToString(), "OK");
                }
            }
            catch(Exception ex)
            {

            }
        }

        private async void OnMessagePopup_Clicked(object sender, EventArgs e)
        {
            try
            {
                await _popupNavigation.PushAsync<MessagePopup>(this.Navigation, null, CancellationToken.None, new MessagePopupModel
                {
                    Title = "Test message popup title",
                    Message = "Test message popup message"
                });
            }
            catch(Exception ex)
            {

            }

        }

        private async void OnAddPopup_Clicked(object sender, EventArgs e)
        {
            try
            {
                await _popupNavigation.PushAsync<AddPopup>(this.Navigation, null, CancellationToken.None);
            }
            catch(Exception ex)
            {

            }
        }

        private async void OnLoaderPopup_Clicked(object sender, EventArgs e)
        {
            await using AppLoader loader = await AppLoader.CreateAsync("Loading...");

            await Task.Delay(10000);
        }
    }
}
