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

namespace ResourceDroidForSWLCG
{
    [Activity(Label = "Errata (v5.0)")]
    public class ErrataActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here            
            WebView webView = new WebView(this);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.PluginsEnabled = true;
            webView.LoadUrl("https://docs.google.com/gview?embedded=true&url=" +
                Resources.GetString(Resource.String.errataPdf));
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