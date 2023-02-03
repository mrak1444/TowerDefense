using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public interface iDefense  //защита
    {
        string NameDefense { get; }
        int ShotPower { get; }
        float ShotRange { get; }
        float TimeShots { get; }
        List<iEnemy> Enemy { get; }
        Transform TransformDefense { get; }
    }
}


