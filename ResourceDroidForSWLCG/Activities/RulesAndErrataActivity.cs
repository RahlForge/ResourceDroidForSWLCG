using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace ResourceDroidForSWLCG.Activities
{
    [Activity(Label = "Rules & Errata", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class RulesAndErrataActivity : ResourceDroidActivity
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
    }
}