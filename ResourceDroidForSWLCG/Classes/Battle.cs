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
    public class Battle
    {
        public Faction SelectedFaction { get; set; }
        public int DeathStarDialCount { get; set; }
        public int ReserveCount { get; set; }
        public List<Resource> ResourceList { get; set; }

        public Battle()
        {

        }
    }
}