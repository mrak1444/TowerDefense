using UnityEngine;

namespace TowerDefanse
{
    public interface iCheckpoint
    {
        Transform ThisTarget { get; }
        iCheckpoint NextTarget { get; }
    }
}


