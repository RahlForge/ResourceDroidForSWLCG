package md5b12aa9f3ab95f43eff127a7ab18cbfd2;


public class EmbeddedWebViewClient
	extends android.webkit.WebViewClient
	implements
		mono.android.IGCUserPeer,
		android.webkit.ValueCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPageFinished:(Landroid/webkit/WebView;Ljava/lang/String;)V:GetOnPageFinished_Landroid_webkit_WebView_Ljava_lang_String_Handler\n" +
			"n_onReceiveValue:(Ljava/lang/Object;)V:GetOnReceiveValue_Ljava_lang_Object_Handler:Android.Webkit.IValueCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("ResourceDroidForSWLCG.EmbeddedWebViewClient, ResourceDroidForSWLCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", EmbeddedWebViewClient.class, __md_methods);
	}


	public EmbeddedWebViewClient ()
	{
		super ();
		if (getClass () == EmbeddedWebViewClient.class)
			mono.android.TypeManager.Activate ("ResourceDroidForSWLCG.EmbeddedWebViewClient, ResourceDroidForSWLCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public EmbeddedWebViewClient (android.webkit.WebView p0)
	{
		super ();
		if (getClass () == EmbeddedWebViewClient.class)
			mono.android.TypeManager.Activate ("ResourceDroidForSWLCG.EmbeddedWebViewClient, ResourceDroidForSWLCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Webkit.WebView, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void onPageFinished (android.webkit.WebView p0, java.lang.String p1)
	{
		n_onPageFinished (p0, p1);
	}

	private native void n_onPageFinished (android.webkit.WebView p0, java.lang.String p1);


	public void onReceiveValue (java.lang.Object p0)
	{
		n_onReceiveValue (p0);
	}

	private native void n_onReceiveValue (java.lang.Object p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
