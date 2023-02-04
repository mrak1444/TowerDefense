using UnityEngine;

namespace TowerDefanse
{
    public interface iTower
    {
        Transform TowerPosition { get; }
        int HP { get; set; }
    }
}


