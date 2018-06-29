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
    public class Faction
    {
        public int ResourceId { get; protected set; }
        public string Name { get; protected set; }
        public int Force { get; protected set; }
        public int StartingReserve { get; protected set; }
        public int Reserve { get; set; }

        public Faction(int resourceId, string name, int force, int startingReserve)
        {
            this.Name = name;
            this.Force = force;
            this.StartingReserve = startingReserve;
            this.Reserve = startingReserve;
        }
    }

    internal class FactionList
    {
        private List<Faction> factionList;

        public FactionList()
        {
            factionList = new List<Faction>();
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
                if (f.Name == name)
                    return f;
            }
            return null;
        }

        public FactionList GetFactionListByForce(int force)
        {
            FactionList fl = new FactionList();
            foreach (Faction f in factionList)
            {
                if (f.Force == force)
                    fl.Add(f);
            }
            return fl;
        }
    }
}