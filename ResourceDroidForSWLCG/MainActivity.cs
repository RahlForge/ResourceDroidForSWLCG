using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;
using Android.Content;

namespace ResourceDroidForSWLCG
{
    [Activity(Label = "Resource Droid", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        private Spinner factionSpinner;
        private ArrayAdapter lightSideFactionAdapter;
        private ArrayAdapter darkSideFactionAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Set the Death Star Dial and Balance of the Force tokens
            var deathStarDialButton = FindViewById<Button>(Resource.Id.deathStarDial);
            deathStarDialButton.Click += DeathStarDialButton_Click;
            deathStarDialButton.LongClick += DeathStarDialButton_LongClick;

            var forceBalanceButton = FindViewById<Button>(Resource.Id.forceToken);
            forceBalanceButton.Tag = GetString(Resource.String.ls_force);
            forceBalanceButton.Click += ForceBalanceButton_Click;

            // Assing values to the Force Alignment spinner
            var forceAlignmentSpinner = FindViewById<Spinner>(Resource.Id.forceAlignment);
            forceAlignmentSpinner.ItemSelected += ForceAlignmentSpinner_ItemSelected;

            var forceAlignmentAdapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.force_alignment, Android.Resource.Layout.SimpleSpinnerItem);
            forceAlignmentAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            forceAlignmentSpinner.Adapter = forceAlignmentAdapter;

            factionSpinner = FindViewById<Spinner>(Resource.Id.faction);
            factionSpinner.ItemSelected += FactionSpinner_ItemSelected;

            var incReserveButton = FindViewById<Button>(Resource.Id.increaseReserve);
            incReserveButton.Click += IncReserveButton_Click;

            var decReserveButton = FindViewById<Button>(Resource.Id.decreaseReserve);
            decReserveButton.Click += DecReserveButton_Click;

            var resetButton = FindViewById<Button>(Resource.Id.resetButton);
            resetButton.Click += ResetButton_Click;

            lightSideFactionAdapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.light_side_factions, Android.Resource.Layout.SimpleSpinnerItem);
            lightSideFactionAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            darkSideFactionAdapter = ArrayAdapter.CreateFromResource(
                this, Resource.Array.dark_side_factions, Android.Resource.Layout.SimpleSpinnerItem);
            darkSideFactionAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Reset Force alignment to Dark Side
            ((Spinner)FindViewById<Spinner>(Resource.Id.forceAlignment)).SetSelection(0);

            // Reset Faction (triggers Reserve reset)
            Spinner fs = FindViewById<Spinner>(Resource.Id.faction);
            fs.Adapter = darkSideFactionAdapter;
            fs.SetSelection(0);

            // Reset Death Star Dial
            ((Button)FindViewById<Button>(Resource.Id.deathStarDial)).Text = GetString(Resource.String.min_death_star);

            // Reset Force Token
            Button ft = FindViewById<Button>(Resource.Id.forceToken);
            ft.SetBackgroundResource(Resource.Drawable.botf_light);
            ft.Tag = GetString(Resource.String.ls_force);
        }

        private void DecReserveButton_Click(object sender, EventArgs e)
        {
            TextView reserve = FindViewById<TextView>(Resource.Id.reserve);
            int currentReserve = Convert.ToInt32(reserve.Text);
            if (currentReserve > 0)
                currentReserve--;
            reserve.Text = currentReserve.ToString();
        }

        private void IncReserveButton_Click(object sender, EventArgs e)
        {
            TextView reserve = FindViewById<TextView>(Resource.Id.reserve);
            int currentReserve = Convert.ToInt32(reserve.Text);
            currentReserve++;
            reserve.Text = currentReserve.ToString();
        }

        private void FactionSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // When a faction is selected, do this
            ((TextView)FindViewById<TextView>(Resource.Id.reserve)).Text = GetString(Resource.String.starting_reserve);
        }

        private void ForceAlignmentSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            // When an alignment is selected, do this
            if (spinner.GetItemAtPosition(e.Position).ToString() == GetString(Resource.String.ls_force))
                factionSpinner.Adapter = lightSideFactionAdapter;
            else
                factionSpinner.Adapter = darkSideFactionAdapter;
        }

        private void ForceBalanceButton_Click(object sender, EventArgs e)
        {
            var token = (Button)sender;
            if (balanceIsLight())
            {
                token.SetBackgroundResource(Resource.Drawable.botf_dark);
                token.Tag = GetString(Resource.String.ds_force);
            }
            else
            {
                token.SetBackgroundResource(Resource.Drawable.botf_light);
                token.Tag = GetString(Resource.String.ls_force);
            }
        }

        private void DeathStarDialButton_Click(object sender, EventArgs e)
        {
            var dsDial = (Button)sender;
            var forceToken = FindViewById<Button>(Resource.Id.forceToken);
            var dialCount = Convert.ToInt32(dsDial.Text);
            var maxCount = Convert.ToInt32(GetString(Resource.String.max_death_star));
            if (dialCount < maxCount)
            {
                dialCount++;
                if (!balanceIsLight() &&
                    dialCount <= maxCount - 1)
                    dialCount++;
                dsDial.Text = dialCount.ToString();
                sender = dsDial;
            }
        }

        private void DeathStarDialButton_LongClick(object sender, Android.Views.View.LongClickEventArgs e)
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.Menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.rules:
                    var intent = new Intent();
                    intent.SetClass(BaseContext, typeof(RulesAndErrataActivity));
                    intent.SetFlags(ActivityFlags.ReorderToFront);
                    StartActivity(intent);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private bool balanceIsLight()
        {
            if (((Button)FindViewById<Button>(Resource.Id.forceToken)).Tag.ToString() == GetString(Resource.String.ls_force))
                return true;
            else
                return false;
        }
    }
}

