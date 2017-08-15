using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;

namespace ResourceDroidForSWLCG
{
    [Activity(Label = "ResourceDroidActivity")]
    public class ResourceDroidActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
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
                    if (this.GetType() != typeof(MainActivity))
                    {
                        intent = new Intent();
                        intent.SetClass(BaseContext, typeof(MainActivity));
                        intent.SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        return true;
                    }
                    else break;
                case Resource.Id.deckbox:
                    if (this.GetType() != typeof(CardDbViewerActivity))
                    {
                        intent = new Intent();
                        intent.SetClass(BaseContext, typeof(CardDbViewerActivity));
                        intent.SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        return true;
                    }
                    else break;
                case Resource.Id.rules:
                    if (this.GetType() != typeof(RulesAndErrataActivity))
                    {
                        intent = new Intent();
                        intent.SetClass(BaseContext, typeof(RulesAndErrataActivity));
                        intent.SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        return true;
                    }
                    else break;
                case Resource.Id.about:
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}