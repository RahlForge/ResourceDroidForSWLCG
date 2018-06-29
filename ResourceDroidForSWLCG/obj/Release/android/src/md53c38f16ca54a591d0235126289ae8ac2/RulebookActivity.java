package md53c38f16ca54a591d0235126289ae8ac2;


public class RulebookActivity
	extends md53c38f16ca54a591d0235126289ae8ac2.ResourceDroidActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ResourceDroidForSWLCG.Activities.RulebookActivity, ResourceDroidForSWLCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RulebookActivity.class, __md_methods);
	}


	public RulebookActivity ()
	{
		super ();
		if (getClass () == RulebookActivity.class)
			mono.android.TypeManager.Activate ("ResourceDroidForSWLCG.Activities.RulebookActivity, ResourceDroidForSWLCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
