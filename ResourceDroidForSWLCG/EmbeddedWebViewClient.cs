using System;
using Android.Content;
using Android.Webkit;
using Java.Interop;
using Android.Runtime;

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

            view.EvaluateJavascript("javascript:HtmlViewer.showHTML(" +
                "'<html>'+document.getElementById('searchUL').innerHTML+'</html>);", this);
        }

        public void OnReceiveValue(Java.Lang.Object html)
        {
        }
    }
}