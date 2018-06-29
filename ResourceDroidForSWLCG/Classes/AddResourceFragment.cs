using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ResourceDroidForSWLCG.Classes
{
    public class AddResourceFragment : DialogFragment
    {
        public event DialogEventHandler Dismissed;
        public string ResourceName { get; set; }
        public int ResourceCount { get; set; }

        public static AddResourceFragment NewInstance(Bundle bundle)
        {
            AddResourceFragment fragment = new AddResourceFragment
            {
                Arguments = bundle
            };
            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.AddResource, container, false);
            EditText resourceName = view.FindViewById<EditText>(Resource.Id.resourceNameEditText);
            EditText resourceCount = view.FindViewById<EditText>(Resource.Id.resourceCountEditText);
            Button okButton = view.FindViewById<Button>(Resource.Id.okAddResourceButton);
            Button cancelButton = view.FindViewById<Button>(Resource.Id.cancelAddResourceButton);

            okButton.Click += delegate
            {
                Dismiss();
                Dismissed?.Invoke(this, new AddResourceDialogEventArgs
                {
                    ResourceName = resourceName.Text,
                    ResourceCount = Convert.ToInt32(resourceCount.Text)
                });                
            };

            cancelButton.Click += delegate
            {
                Dismiss();
            };

            return view;
        }
    }
}