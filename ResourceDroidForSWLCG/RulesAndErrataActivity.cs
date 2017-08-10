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

namespace ResourceDroidForSWLCG
{
    [Activity(Label = "Rules & Errata")]
    public class RulesAndErrataActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RulesAndErrata);

            var rulebookButton = FindViewById<Button>(Resource.Id.rulebookButton);
            rulebookButton.Click += RulebookButton_Click;

            var errataButton = FindViewById<Button>(Resource.Id.errataButton);
            errataButton.Click += ErrataButton_Click;
        }

        private void ErrataButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(BaseContext, typeof(ErrataActivity));
            intent.SetFlags(ActivityFlags.ReorderToFront);
            StartActivity(intent);
        }

        private void RulebookButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(BaseContext, typeof(RulebookActivity));
            intent.SetFlags(ActivityFlags.ReorderToFront);
            StartActivity(intent);
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