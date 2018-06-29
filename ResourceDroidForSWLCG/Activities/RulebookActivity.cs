using Android.App;
using Android.OS;
using Android.Webkit;

namespace ResourceDroidForSWLCG.Activities
{
    [Activity(Label = "Core Rulebook", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class RulebookActivity : ResourceDroidActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            WebView webView = new WebView(this);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.AllowFileAccessFromFileURLs = true;
            webView.Settings.AllowUniversalAccessFromFileURLs = true;
            webView.Settings.BuiltInZoomControls = true;
            webView.Settings.DisplayZoomControls = false;
            webView.Settings.LoadWithOverviewMode = true;
            webView.Settings.UseWideViewPort = true;
            webView.LoadUrl(Resources.GetString(Resource.String.rulebookHtml));
            SetContentView(webView);
        }
    }
}