using Android.App;
using Android.OS;
using Android.Webkit;

namespace ResourceDroidForSWLCG
{
    [Activity(Label = "Errata (v5.0)")]
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
            webView.LoadUrl("file:///android_asset/pdfjs/web/viewer.html?file=file:///android_asset/Content/" + Resources.GetString(Resource.String.errataPdf));
            SetContentView(webView);
        }
    }
}