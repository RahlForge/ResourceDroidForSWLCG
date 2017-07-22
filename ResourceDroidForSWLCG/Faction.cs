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

namespace ResourceDroidForSWLCG
{
    internal class Faction
    {
        public int resourceId { get; protected set; }
        public string name { get; protected set; }
        public int force { get; protected set; }
        public int startingReserve { get; protected set; }
        public int reserve { get; set; }

        public Faction(int resourceId, string name, int force, int startingReserve)
        {
            this.name = name;
            this.force = force;
            this.startingReserve = startingReserve;
            this.reserve = startingReserve;
        }
    }

    internal class FactionList
    {
        private List<Faction> factionList;

        public FactionList()
        {

        }

        public void Add(int resourceId, string name, int force, int startingReserve)
        {
            factionList.Add(new Faction(resourceId, name, force, startingReserve));
        }

        public void Add(Faction faction)
        {
            factionList.Add(faction);
        }

        public Faction getFactionByName(string name)
        {
            foreach (Faction f in factionList)
            {
                if (f.name == name)
                    return f;
            }
            return null;
        }

        public FactionList getFactionListByForce(int force)
        {
            FactionList fl = new FactionList();
            foreach (Faction f in factionList)
            {
                if (f.force == force)
                    fl.Add(f);
            }
            return fl;
        }
    }
}