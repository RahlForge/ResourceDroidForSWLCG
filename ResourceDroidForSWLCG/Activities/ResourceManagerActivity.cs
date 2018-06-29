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
using ResourceDroidForSWLCG.Classes;

namespace ResourceDroidForSWLCG.Activities
{
    [Activity(Label = "Resource Manager", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ResourceManagerActivity : ResourceDroidActivity
    {
        private List<SWResource> resourceList;
        private ListView resourceListView;
        private ResourceListAdapter resourceListAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ResourceManager);
            resourceList = new List<SWResource>();

            // Death Star Dial
            var deathStarDialButton = FindViewById<Button>(Resource.Id.deathStarDialButton);
            deathStarDialButton.Click += DeathStarDialButton_Click;
            deathStarDialButton.LongClick += DeathStarDialButton_LongClick;

            // Balance of the Force Token
            var forceBalanceButton = FindViewById<Button>(Resource.Id.forceTokenButton);
            forceBalanceButton.Tag = GetString(Resource.String.ls_force);
            forceBalanceButton.Click += ForceBalanceButton_Click;

            // Reserve Increase/Decrease
            var incReserveButton = FindViewById<Button>(Resource.Id.increaseReserveButton);
            incReserveButton.Click += AlterReserve;

            var decReserveButton = FindViewById<Button>(Resource.Id.decreaseReserveButton);
            decReserveButton.Click += AlterReserve;

            // Reset Button
            var resetButton = FindViewById<Button>(Resource.Id.resetButton);
            resetButton.Click += ResetButton_Click;

            // Resources
            resourceListView = FindViewById<ListView>(Resource.Id.resourcesListView);
            resourceListAdapter = new ResourceListAdapter(this, resourceList);
            resourceListView.Adapter = resourceListAdapter;

            var addResourceButton = FindViewById<Button>(Resource.Id.addResourceButton);
            addResourceButton.Click += AddResourceButton_Click;

            var refreshButton = FindViewById<Button>(Resource.Id.refreshButton);
            refreshButton.Click += RefreshButton_Click;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlterReserve(object sender, EventArgs e)
        {
            TextView reserve = FindViewById<TextView>(Resource.Id.reserveCountTextView);
            int currentReserve = Convert.ToInt32(reserve.Text);
            currentReserve += Convert.ToInt32(((Button)sender).Tag.ToString());
            reserve.Text = currentReserve.ToString();
        }

        /// <summary>
        /// Resets the view to default values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Reset Death Star Dial
            ((Button)FindViewById<Button>(Resource.Id.deathStarDialButton)).Text = GetString(Resource.String.min_death_star);

            // Reset Force Token
            Button ft = FindViewById<Button>(Resource.Id.forceTokenButton);
            ft.SetBackgroundResource(Resource.Drawable.botf_light);
            ft.Tag = GetString(Resource.String.ls_force);

            // Clear the resource list
            resourceList.Clear();
            resourceListAdapter.NotifyDataSetChanged();
        }

        #region Resources
        /// <summary>
        /// Creates a new resource to add to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddResourceButton_Click(object sender, EventArgs e)
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            Fragment lastRun = FragmentManager.FindFragmentByTag("addResourceDialog");
            if (lastRun != null)
                ft.Remove(lastRun);
            ft.AddToBackStack(null);
            AddResourceFragment dialog = AddResourceFragment.NewInstance(null);
            dialog.Dismissed += (s, args) =>
            {                
                resourceList.Add(new SWResource(args.ResourceName, args.ResourceCount));
                resourceListAdapter.NotifyDataSetChanged();
            };
            dialog.Show(ft, "addResourceDialog");
        }

        /// <summary>
        /// Refreshes all the resources in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            foreach(SWResource r in resourceList)
            {
                if (r.FocusCount > 0)
                    r.Refresh();
            }
            resourceListAdapter.NotifyDataSetChanged();
        }
        #endregion

        #region Death Star Dial
        /// <summary>
        /// Handles a short tap of the Death Star Dial, incrementing the
        /// dial's face value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeathStarDialButton_Click(object sender, EventArgs e)
        {
            var dsDial = (Button)sender;
            var forceToken = FindViewById<Button>(Resource.Id.forceTokenButton);
            var dialCount = Convert.ToInt32(dsDial.Text);
            var maxCount = Convert.ToInt32(GetString(Resource.String.max_death_star));
            if (dialCount < maxCount)
            {
                dialCount++;
                if (BalanceIsDark &&
                    dialCount <= maxCount - 1)
                    dialCount++;
                dsDial.Text = dialCount.ToString();
                sender = dsDial;
            }
        }

        /// <summary>
        /// Handles a long-press of the Death Star Dial, decrementing the dial's face value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeathStarDialButton_LongClick(object sender, View.LongClickEventArgs e)
        {
            var dsDial = (sender as Button);
            var dialCount = Convert.ToInt32(dsDial.Text);
            if (dialCount > Convert.ToInt32(GetString(Resource.String.min_death_star)))
            {
                dialCount--;
                dsDial.Text = dialCount.ToString();
                sender = dsDial;
            }
        }
        #endregion

        #region Balance of the Force
        /// <summary>
        /// Handles a press of the Balance of the Force Token, flipping it to the opposite side
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForceBalanceButton_Click(object sender, EventArgs e)
        {
            var token = (Button)sender;
            if (BalanceIsDark)
            {
                token.SetBackgroundResource(Resource.Drawable.botf_light);
                token.Tag = GetString(Resource.String.ls_force);
            }
            else
            {
                token.SetBackgroundResource(Resource.Drawable.botf_dark);
                token.Tag = GetString(Resource.String.ds_force);
            }
        }

        /// <summary>
        /// Returns true is the Balance of the Force is currently to the Dark Side
        /// </summary>
        private bool BalanceIsDark
        {
            get
            {
                if (FindViewById<Button>(Resource.Id.forceTokenButton).Tag.ToString() == 
                    GetString(Resource.String.ds_force))
                    return true;
                else
                    return false;
            }
        }
        #endregion
    }
}