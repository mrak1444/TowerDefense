using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public interface iTarget
    {
        Transform TargetTransform { get; }
        int Hp { get; set; }
    }
}


