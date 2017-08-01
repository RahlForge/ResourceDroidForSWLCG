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
    [Activity(Label = "RuleActivity")]
    public class RuleActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Rule);

            var ruleText = FindViewById<TextView>(Resource.Id.textView);
            ruleText.Text = Resources.GetString(Resource.String.gameOverviewText);
        }
    }
}