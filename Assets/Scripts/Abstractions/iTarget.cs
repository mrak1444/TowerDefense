using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public interface iTarget
    {
        GameObject GameObject { get; }
        Transform TargetTransform { get; }
        int Hp { get; set; }
    }
}


