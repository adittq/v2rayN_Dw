using Foundation;
using UIKit;

namespace V2rayN.iOS;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow Window { get; set; }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        Window = new UIWindow(UIScreen.MainScreen.Bounds);
        var vc = new UIViewController();
        var label = new UILabel
        {
            Text = "v2rayN_Dw iOS 已启动",
            TextAlignment = UITextAlignment.Center,
            Frame = Window.Bounds,
            Lines = 1
        };
        vc.View.AddSubview(label);
        Window.RootViewController = vc;
        Window.MakeKeyAndVisible();
        return true;
    }
}

