using UnityEngine;

namespace TowerDefanse
{
    internal interface IAmmunition
    {
        int ShotPower { get; set; }
        iTarget Target { get; set; }
        GameObject Obj { get; }
    }
}