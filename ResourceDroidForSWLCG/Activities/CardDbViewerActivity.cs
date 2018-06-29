using Android.App;
using Android.OS;
using Android.Webkit;
using Android.Widget;

namespace ResourceDroidForSWLCG.Activities
{
    [Activity(Label = "Card Search", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class CardDbViewerActivity : ResourceDroidActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CardDbViewer);

            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            searchButton.Click += SearchButton_Click;

            var searchName = FindViewById<TextView>(Resource.Id.cardSearchName);
            searchName.Click += SearchName_Click;

            var webView = FindViewById<WebView>(Resource.Id.cardDbView);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.BuiltInZoomControls = true;
            webView.Settings.DisplayZoomControls = false;
            webView.LoadUrl("http://www.cardgamedb.com/index.php/starwars/star-wars-deckbuilder");
        }

        private void SearchName_Click(object sender, System.EventArgs e)
        {
            ((TextView)sender).Text = "";
        }

        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            var searchUrl = Resources.GetString(Resource.String.cardSearchUrl);
            var searchCard = FindViewById<TextView>(Resource.Id.cardSearchName).Text;
            searchCard = searchCard.Replace(" ", "%20"); // Replace spaces with html-encoded characters
            searchUrl = searchUrl.Replace("thecard", searchCard); // Replace search placeholder with requested value

            HideKeyboard(this);

            var webView = FindViewById<WebView>(Resource.Id.cardDbView);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.BuiltInZoomControls = true;
            webView.Settings.DisplayZoomControls = false;
            webView.SetWebViewClient(new EmbeddedWebViewClient(webView));
            webView.LoadUrl(searchUrl);
        }
    }
}