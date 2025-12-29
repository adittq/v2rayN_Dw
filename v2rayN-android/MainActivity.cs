using Android.App;
using Android.OS;
using Android.Widget;

namespace V2rayN.Android;

[Activity(Label = "v2rayN_Dw", MainLauncher = true, Theme = "@android:style/Theme.Material.Light")]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        var tv = new TextView(this);
        tv.Text = "v2rayN_Dw Android 已启动";
        tv.SetPadding(40, 80, 40, 40);
        tv.TextSize = 18;
        SetContentView(tv);
    }
}

