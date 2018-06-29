using Android.App;
using Android.OS;
using Android.Webkit;

namespace ResourceDroidForSWLCG.Activities
{
    [Activity(Label = "Errata (v5.0)", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ErrataActivity : ResourceDroidActivity
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
            webView.LoadUrl(Resources.GetString(Resource.String.errataHtml));
            SetContentView(webView);
        }
    }
}