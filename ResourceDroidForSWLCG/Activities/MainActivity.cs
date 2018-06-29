using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace ResourceDroidForSWLCG.Activities
{
    [Activity(Label = "Resource Droid for SWLCG", MainLauncher = true, Icon = "@drawable/Icon", 
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : ResourceDroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ActionBar.SetTitle(Resource.String.MainActivityLabel);

            var newGameButton = FindViewById<Button>(Resource.Id.newGameButton);
            newGameButton.Click += NewGameButton_Click;
        }

        /// <summary>
        /// Creates a new instance of Resource Management. It offers to save the
        /// current state of the manager, first.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

