namespace PopupProto.Loader;

public partial class LoadingPopups : ContentPage
{
	public LoadingPopups()
	{
		InitializeComponent();
    }

    private async void OnLoaderPopup_Clicked(object sender, EventArgs e)
    {
        await using AppLoader loader = await AppLoader.CreateAsync("Loading...");

        await Task.Delay(10000);
    }
}