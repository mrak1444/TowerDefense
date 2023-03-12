using UnityEngine;

namespace TowerDefanse
{
    public interface iSelectable
    {
        Transform Position { get; }
        iSelectable Selected();
    }
}
