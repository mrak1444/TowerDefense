using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public static class GameProfile
    {
        private static List<iTarget> _enemys = new List<iTarget>();
        private static SubscriptionProperty<bool> _flagFindSelect = new SubscriptionProperty<bool>();
        private static string _menuName;
        private static Vector3 _menuPosition = new Vector3(0,1,0);
        private static iSelectable _selectedMenu;
        private static SubscriptionProperty<int> _moneyInLevel = new SubscriptionProperty<int>();
        private static SubscriptionProperty<int> _waveNow = new SubscriptionProperty<int>();
        private static int _wavesAll;
        private static bool _gameOver = false;
        private static bool _levelWin = false;
        private static GameObject _levelObj;
        private static List<GameObject> _defenseObj = new List<GameObject>();

        public static List<iTarget> Enemys { get => _enemys; set => _enemys = value; }
        public static SubscriptionProperty<bool> FlagFindSelect { get => _flagFindSelect; set => _flagFindSelect = value; }
        public static string MenuName { get => _menuName; set => _menuName = value; }
        public static Vector3 MenuPosition { get => _menuPosition; set => _menuPosition = value; }
        public static iSelectable SelectedMenu { get => _selectedMenu; set => _selectedMenu = value; }
        public static SubscriptionProperty<int> MoneyInLevel { get => _moneyInLevel; set => _moneyInLevel = value; }
        public static SubscriptionProperty<int> WaveNow { get => _waveNow; set => _waveNow = value; }
        public static int WavesAll { get => _wavesAll; set => _wavesAll = value; }
        public static bool GameOver { get => _gameOver; set => _gameOver = value; }
        public static bool LevelWin { get => _levelWin; set => _levelWin = value; }
        public static GameObject LevelObj { get => _levelObj; set => _levelObj = value; }
        public static List<GameObject> DefenseObj { get => _defenseObj; set => _defenseObj = value; }
    }
}


