using PopupProto.BaseLayouts;

namespace PopupProto;

public partial class AddPopup : BasePopup
{
    public AddPopup()
    {
        InitializeComponent();
    }

    public override void SetLoadValues(Border container)
    {
        container.Opacity = 0;
        container.TranslationY = -200;
    }

    public override void AnimationOnOpen(Border container)
    {
        Animation openAnimation = new()
        {
            { 0, 1, new Animation(_ => container.Opacity = _, container.Opacity, 1, Easing.SinOut) },
            { 0, 1, new Animation(_ => container.TranslationY = _, container.TranslationY, 0, Easing.SinOut) }
        };

        openAnimation.Commit(this, nameof(openAnimation), 16, 700u, null);
    }

    public override void AnimationOnClose(Border container)
    {
        Animation closeAnimation = new()
        {
            { 0, 1, new Animation(_ => container.Opacity = _, container.Opacity, 0, Easing.SinIn) },
            { 0, 1, new Animation(_ => container.TranslationY = _, container.TranslationY, -200, Easing.SinIn) }
        };

        closeAnimation.Commit(this, nameof(closeAnimation), 16, 300u, null);
    }
}