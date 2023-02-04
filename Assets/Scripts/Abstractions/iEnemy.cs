using UnityEngine;

namespace TowerDefanse
{
    public interface iEnemy
    {
        string NameEnemy { get; }
        float ShotPower { get; }
        float ShotRange { get; }
        float TimeShots { get; }
        float SpeedEnemy { get; }
        int Hp { get; set; }
        Transform TransformEnemy { get; }
        iCheckpoint Target { get; set; }
    }
}

