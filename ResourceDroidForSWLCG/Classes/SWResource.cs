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
    public class SWResource
    {
        public string Name { get; set; }
        public int ResourceCount { get; set; }
        public int FocusCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="resourceCount"></param>
        public SWResource(string name, int resourceCount = 1)
        {
            Name = name;
            ResourceCount = resourceCount;
            FocusCount = 0;
        }

        /// <summary>
        /// Adds a focus to the resource
        /// </summary>
        public void Focus()
        {
            FocusCount++;
        }

        /// <summary>
        /// Removes a focus from the resource
        /// </summary>
        public void Refresh()
        {
            FocusCount--;
        }
    }
}