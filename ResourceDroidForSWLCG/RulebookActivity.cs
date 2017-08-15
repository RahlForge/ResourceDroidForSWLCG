using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using System.Net;
using Java.IO;

namespace ResourceDroidForSWLCG
{
    [Activity(Label = "Core Rulebook")]
    public class RulebookActivity : Activity
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
            webView.LoadUrl("file:///android_asset/pdfjs/web/viewer.html?file=file:///android_asset/Content/" + Resources.GetString(Resource.String.rulebookPdf));
            SetContentView(webView);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.Menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Intent intent;
            switch (item.ItemId)
            {
                case Resource.Id.resources:
                    intent = new Intent();
                    intent.SetClass(BaseContext, typeof(MainActivity));
                    intent.SetFlags(ActivityFlags.ReorderToFront);
                    StartActivity(intent);
                    return true;
                case Resource.Id.rules:
                    intent = new Intent();
                    intent.SetClass(BaseContext, typeof(RulesAndErrataActivity));
                    intent.SetFlags(ActivityFlags.ReorderToFront);
                    StartActivity(intent);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}