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

namespace ResourceDroidForSWLCG.Classes
{
    public class AddResourceDialogEventArgs : EventArgs
    {
        public string ResourceName { get; set; }
        public int ResourceCount { get; set; }
    }

    public delegate void DialogEventHandler(object sender, AddResourceDialogEventArgs args);
}