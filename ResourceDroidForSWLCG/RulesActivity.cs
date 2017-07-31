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
using SWLCGCounter;

namespace ResourceDroidForSWLCG
{
    [Activity(Label = "RulesActivity")]
    public class RulesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Rules);

            var rulesMenuList = FindViewById<ListView>(Resource.Id.rulesMenu);
            var rulesMenuAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Resources.GetStringArray(Resource.Array.contents));
            rulesMenuList.Adapter = rulesMenuAdapter;
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
                    intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    return true;
                case Resource.Id.rules:
                    intent = new Intent(this, typeof(RulesActivity));
                    StartActivity(intent);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}