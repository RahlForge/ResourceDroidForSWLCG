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
using Android.Util;

namespace ResourceDroidForSWLCG
{
    class EmbeddedWebViewClient : WebViewClient, IValueCallback
    {
        public EmbeddedWebViewClient(WebView view)
        {
            view.Settings.JavaScriptEnabled = true;
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            //Log.Info("SO", $"Page loaded from: {url}");
            view.EvaluateJavascript("document.getElementsByClassName('searchImgCard')[0].innerHTML", this);
        }

        public void OnReceiveValue(Java.Lang.Object value)
        {
            // "value" holds the html contents of the loaded page
            // Log.Debug("SO", ((string)value).Substring(0, 40));
        }
    }
}