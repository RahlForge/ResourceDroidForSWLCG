using Android.App;
using Android.OS;
using Android.Webkit;

namespace ResourceDroidForSWLCG
{
    [Activity(Label = "Deckbox")]
    public class CardDbViewerActivity : ResourceDroidActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CardDbViewer);

            var webView = FindViewById<WebView>(Resource.Id.cardDbView);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.AllowFileAccessFromFileURLs = true;
            webView.Settings.AllowUniversalAccessFromFileURLs = true;
            webView.Settings.BuiltInZoomControls = true;
            webView.LoadUrl("http://www.cardgamedb.com/index.php/starwars/star-wars-deckbuilder");            
        }
    }
}