using UnityEngine;

namespace TowerDefanse
{
    public interface iEnemy
    {
        string NameEnemy { get; }
        int ShotPower { get; }
        float ShotRange { get; }
        float TimeShots { get; }
        float SpeedEnemy { get; }
        iCheckpoint Target { get; set; }
    }
}

