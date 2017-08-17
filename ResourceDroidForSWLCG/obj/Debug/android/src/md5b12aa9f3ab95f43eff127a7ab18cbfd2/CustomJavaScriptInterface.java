package md5b12aa9f3ab95f43eff127a7ab18cbfd2;


public class CustomJavaScriptInterface
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_showHTML:(Ljava/lang/String;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("ResourceDroidForSWLCG.CustomJavaScriptInterface, ResourceDroidForSWLCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CustomJavaScriptInterface.class, __md_methods);
	}


	public CustomJavaScriptInterface () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CustomJavaScriptInterface.class)
			mono.android.TypeManager.Activate ("ResourceDroidForSWLCG.CustomJavaScriptInterface, ResourceDroidForSWLCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public CustomJavaScriptInterface (android.content.Context p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == CustomJavaScriptInterface.class)
			mono.android.TypeManager.Activate ("ResourceDroidForSWLCG.CustomJavaScriptInterface, ResourceDroidForSWLCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void showHTML (java.lang.String p0)
	{
		n_showHTML (p0);
	}

	private native void n_showHTML (java.lang.String p0);

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
