using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public static class GameProfile
    {
        public static SubscriptionProperty<bool> FlagFindSelect = new SubscriptionProperty<bool>();
        public static string MenuName;
        public static Vector3 MenuPosition = new Vector3(0,1,0);
        public static iSelectable SelectedMenu;
        //public static int MoneyInLevel;
        public static SubscriptionProperty<int> MoneyInLevel = new SubscriptionProperty<int>();
        public static SubscriptionProperty<int> WaveNow = new SubscriptionProperty<int>();
        public static int WavesAll;
    }
}


