using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public interface iDefense  //защита
    {
        string NameDefense { get; }
        float ShotPower { get; }
        float ShotRange { get; }
        float TimeShots { get; }
        List<iEnemy> Enemys { get; }
        Transform TransformDefense { get; }
    }
}


