using UnityEngine;

namespace TowerDefanse
{
    public interface iCheckpoint
    {
        Transform TargetTransform { get; }
        iCheckpoint NextTarget { get; }
        string NameTarget { get; }
        iTarget itarget { get; }
    }
}


