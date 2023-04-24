#if IOS
using UIKit;
#endif


#if ANDROID
using Android.Content.Res;
#endif

using Microsoft.Maui.Controls.Platform;

namespace tripshare.effects;


internal class EntryBackgroundTintEffect : RoutingEffect
{
}
#if ANDROID
internal class AndroidEntryNoBackgroundTintEffect : PlatformEffect
{
    protected override void OnAttached()
    {
        if (Control == null) return;
        var entryUnderlineColor = Android.Graphics.Color.Transparent;
        Control.BackgroundTintList = ColorStateList.ValueOf(entryUnderlineColor);
    }

    protected override void OnDetached()
    {
        // Cleanup the control customization here
    }
}
#elif IOS
internal class IosEntryNoBackgroundTintEffect : PlatformEffect
{
    protected override void OnAttached()
    {
       if (Control == null) return;
       Control.Layer.BorderWidth = 0;
       ((UITextField)Control).BorderStyle = UITextBorderStyle.None;
    }

    protected override void OnDetached()
    {
        // Cleanup the control customization here
    }
}
#endif