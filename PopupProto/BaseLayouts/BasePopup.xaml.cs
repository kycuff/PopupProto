using CommunityToolkit.Maui.Views;

namespace PopupProto.BaseLayouts;

public partial class BasePopup : Popup
{
    public static readonly BindableProperty PopupTitleProperty =
        BindableProperty.Create(nameof(PopupTitle), typeof(string), typeof(BasePopup), null, BindingMode.OneTime, propertyChanged: PopupTitle_PropertyChanged);

    public string PopupTitle
    {
        get => (string)GetValue(PopupTitleProperty);
        set => SetValue(PopupTitleProperty, value);
    }

    public static readonly BindableProperty BasePopupContentProperty =
        BindableProperty.Create(nameof(BasePopupContent), typeof(View), typeof(BasePopup), null, propertyChanged: BasePopupContent_PropertyChanged);

    public View BasePopupContent
    {
        get => (View)GetValue(BasePopupContentProperty);
        set => SetValue(BasePopupContentProperty, value);
    }

    public static readonly BindableProperty PopupVerticalOptionsProperty =
        BindableProperty.Create(nameof(PopupVerticalOptions), typeof(LayoutOptions), typeof(BasePopup), LayoutOptions.Center, propertyChanged: PopupVerticalOptions_PropertyChanged);

    public LayoutOptions PopupVerticalOptions
    {
        get => (LayoutOptions)GetValue(PopupVerticalOptionsProperty);
        set => SetValue(PopupVerticalOptionsProperty, value);
    }

    private bool _isFirstLoad = true;

    public BasePopup()
    {
        InitializeComponent();

        Opened += async (s, e) =>
        {
            if(BindingContext is IPageOnAppearing onAppearing)
            {
                await onAppearing.OnAppearing();
            }

            if(_isFirstLoad)
            {
                await Initialise();

                if(BindingContext is IPageInitialise pageInitialise)
                {
                    await pageInitialise.Initialise();
                }
            }

            AnimationOnOpen();

            _isFirstLoad = false;

            LblTitle.Focus();
        };
    }

    public virtual void AnimationOnOpen()
    {
        Animation loadingAnimation = new()
        {
            { 0, 1, new Animation(_ => Opacity = _, Opacity, 1, Easing.CubicIn) },
            { 0, 1, new Animation(_ => Scale = _, Scale, 1, Easing.BounceOut) }
        };

        loadingAnimation.Commit(this, nameof(loadingAnimation), 16, 3500u, null);
    }

    public virtual void AnimationOnClose()
    {

    }

    public virtual Task Initialise()
    {
        return Task.CompletedTask;
    }

    private async void BtnClose_OnClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
    }

    private static void BasePopupContent_PropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is BasePopup basePopup)
        {
            basePopup.BaseContent.Content = basePopup.BasePopupContent;
        }
    }

    private static void PopupTitle_PropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is BasePopup basePopup)
        {
            basePopup.LblTitle.Text = basePopup.PopupTitle;
        }
    }

    private static void PopupVerticalOptions_PropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is BasePopup basePopup)
        {
            basePopup.VerticalOptions = basePopup.PopupVerticalOptions;
        }
    }
}

public interface IPageOnAppearing
{
    Task OnAppearing();
}

public interface IPageInitialise
{
    Task Initialise();
}