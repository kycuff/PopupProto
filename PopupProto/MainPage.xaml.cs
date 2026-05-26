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

        private async void OnLoadingPopups_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoadingPopups());
        }

        private async void OnReturnObjectPopup_Clicked(object sender, EventArgs e)
        {
            try
            {
                IPopupResult result = await _popupNavigation.PushAsync<SimplePopup>(this.Navigation, null, CancellationToken.None);

                if(result is IPopupResult popupResult)
                {
                    TestObject testObj = new TestObject
                    {
                        Id = 123,
                        Description = "Returned from Popup"
                    };

                    await DisplayAlertAsync("Return Object Result", testObj.ToString(), "OK");
                }
            }
            catch(Exception ex)
            {
                // Handle exceptions appropriately
            }
        }
    }

    public class TestObject
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Description: {Description}";
        }
    }
}
