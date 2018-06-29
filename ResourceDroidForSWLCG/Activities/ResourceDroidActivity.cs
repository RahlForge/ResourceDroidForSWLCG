using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;

namespace ResourceDroidForSWLCG.Activities
{
    [Activity(Label = "ResourceDroidActivity", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
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
                case Resource.Id.main:
                    if (this.GetType() != typeof(MainActivity))
                    {
                        intent = new Intent();
                        intent.SetClass(BaseContext, typeof(MainActivity));
                        intent.SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        return true;
                    }
                    else break;
                case Resource.Id.resources:
                    if (this.GetType() != typeof(ResourceManagerActivity))
                    {
                        intent = new Intent();
                        intent.SetClass(BaseContext, typeof(ResourceManagerActivity));
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

        public static void HideKeyboard(Activity activity)
        {
            InputMethodManager imm = (InputMethodManager)activity.GetSystemService(Activity.InputMethodService);

            //Find the currently focused view, so we can grab the correct window token from it.
            View view = activity.CurrentFocus;

            //If no view currently has focus, create a new one, just so we can grab a window token from it
            if (view == null)
            {
                view = new View(activity);
            }
            imm.HideSoftInputFromWindow(view.WindowToken, 0);
        }
    }
}