using CommunityToolkit.Maui.Animations;

namespace tripshare.behaviors;

public class FadeAndScaleAnimationBehavior : BaseAnimation
{
    public double Scale { get; set; } = 0.6;
    public double Opacity { get; set; } = 1;

    public override async Task Animate(VisualElement view)
    {
        await Task.WhenAll(
            view.ScaleTo(Scale, Length, Easing),
            view.FadeTo(Opacity, Length, Easing)
            );

        await Task.WhenAll(
            view.ScaleTo(1, Length, Easing),
            view.FadeTo(1, Length, Easing)
            );
    }
}