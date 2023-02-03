using UnityEngine;

namespace TowerDefanse
{
    internal interface IAmmunition
    {
        GameObject Obj { get; }
        float SpeedBullet { get; }
        float TimeToDestroy { get; }
        int ShotPower { get; set; }
        iEnemy Target { get; set; }
    }
}