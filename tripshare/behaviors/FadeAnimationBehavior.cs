namespace tripshare.behaviors;

public class FadeAnimationBehavior : Behavior<VisualElement>
{
    public static readonly BindableProperty PageProperty = BindableProperty.Create(
        nameof(Page),
        typeof(ContentPage),
        typeof(FadeAnimationBehavior)
        );

    public FadeAnimationBehavior()
    {
    }

    protected override void OnAttachedTo(VisualElement bindable)
    {
        if (Page is null)
            throw new NullReferenceException($"Require property {nameof(Page)}. Please bind to enclosing ContentPage");

        Page.Appearing += HandlePageAppearing(bindable);

        base.OnAttachedTo(bindable);
    }

    public ContentPage Page
    {
        get => (ContentPage)GetValue(PageProperty);
        set => SetValue(PageProperty, value);
    }

    protected override void OnDetachingFrom(VisualElement bindable)
    {
        base.OnDetachingFrom(bindable);
    }

    private EventHandler HandlePageAppearing(VisualElement bindable)
    {
        return delegate
        {
            Dispatcher.DispatchDelayed(TimeSpan.FromMilliseconds(200), () =>
            {
                bindable.Opacity = 0;
                bindable.TranslationY = 10;

                bindable.FadeTo(1, 2500, Easing.Linear);
                bindable.TranslateTo(0, 0, 800, Easing.SinInOut);
            });

        };
    }
}