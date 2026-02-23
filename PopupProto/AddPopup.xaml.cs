using PopupProto.BaseLayouts;

namespace PopupProto;

public partial class AddPopup : BasePopup
{
	public AddPopup()
	{
		InitializeComponent();

        TranslationY = -200;
    }

    public override void AnimationOnOpen()
    {
        Animation openAnimation = new()
        {
            { 0, 1, new Animation(_ => Opacity = _, 0, 1, Easing.SinOut) },
            { 0, 1, new Animation(_ => Scale = _, 0, 1, Easing.SinOut) },
            { 0, 1, new Animation(_ => TranslationY = _, -200, 0, Easing.SinOut) }
        };

        openAnimation.Commit(this, nameof(openAnimation), 16, 700u, null);
    }

    public override void AnimationOnClose()
    {
        Animation closeAnimation = new()
        {
            { 0, 1, new Animation(_ => Opacity = _, 1, 0, Easing.SinIn) },
            { 0, 1, new Animation(_ => Scale = _, 1, 0, Easing.SinIn) },
            { 0, 1, new Animation(_ => TranslationY = _, 0, -200, Easing.SinIn) }
        };

        closeAnimation.Commit(this, nameof(closeAnimation), 16, 300u, null);
    }
}