using UnityEngine;

namespace TowerDefanse
{
    public interface iEnemy
    {
        string NameEnemy { get; }
        iCheckpoint TargetCheckpoint { get; set; }
        iTarget Tower { get; set; }
    }
}

