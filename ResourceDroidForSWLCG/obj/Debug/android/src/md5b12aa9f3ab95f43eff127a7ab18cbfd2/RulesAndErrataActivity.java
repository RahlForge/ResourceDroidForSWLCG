package md5b12aa9f3ab95f43eff127a7ab18cbfd2;


public class RulesAndErrataActivity
	extends md5b12aa9f3ab95f43eff127a7ab18cbfd2.ResourceDroidActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ResourceDroidForSWLCG.RulesAndErrataActivity, ResourceDroidForSWLCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RulesAndErrataActivity.class, __md_methods);
	}


	public RulesAndErrataActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == RulesAndErrataActivity.class)
			mono.android.TypeManager.Activate ("ResourceDroidForSWLCG.RulesAndErrataActivity, ResourceDroidForSWLCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
