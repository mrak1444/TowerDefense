using System.Collections.Generic;

namespace TowerDefanse
{
    public static class GameData
    {
        private static List<iEnemy> _enemys = new List<iEnemy>();

        public static List<iEnemy> Enemys { get => _enemys; set => _enemys = value; }
    }
}


