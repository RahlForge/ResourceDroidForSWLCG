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
using static Android.Views.View;

namespace ResourceDroidForSWLCG.Classes
{
    public class ResourceListAdapter : BaseAdapter<SWResource>
    {
        Activity context;
        List<SWResource> list;

        public override int Count { get { return list.Count; } }
        public override SWResource this[int index] { get { return list[index]; } }

        public ResourceListAdapter(Activity context, List<SWResource> list)
            :base()
        {
            this.context = context;
            this.list = list;
        }

        public override long GetItemId(int position)
        {
            return position;
        }        

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            // re-use an existing view, if one is available
            // otherwise create a new one
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.ResourceRowLayout, parent, false);

            SWResource item = this[position];
            view.FindViewById<TextView>(Resource.Id.resourceNameCell).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.resourceCountCell).Text = item.ResourceCount.ToString();
            view.FindViewById<TextView>(Resource.Id.focusCountCell).Text = item.FocusCount.ToString();

            Button addFocusButton = view.FindViewById<Button>(Resource.Id.addFocusButton);
            if (!addFocusButton.HasOnClickListeners)
                addFocusButton.Click += (sender, args) => 
                {
                    this[position].Focus();
                    NotifyDataSetChanged();
                };

            Button removeFocusButton = view.FindViewById<Button>(Resource.Id.removeFocusButton);
            if (!removeFocusButton.HasOnClickListeners)
                removeFocusButton.Click += (sender, args) =>
                {
                    this[position].Refresh();
                    NotifyDataSetChanged();
                };

            ImageButton deleteResourceButton = view.FindViewById<ImageButton>(Resource.Id.deleteResourceButton);
            if (!deleteResourceButton.HasOnClickListeners)
                deleteResourceButton.Click += (sender, args) =>
                {
                    list.RemoveAt(position);
                    NotifyDataSetChanged();
                };

            return view;
        }
    }
}