using System.Collections.Generic;

namespace TowerDefanse
{
    public static class GameData
    {
        private static List<iTarget> _enemys = new List<iTarget>();

        public static List<iTarget> Enemys { get => _enemys; set => _enemys = value; }
    }
}


