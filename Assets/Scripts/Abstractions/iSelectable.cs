using UnityEngine;

namespace TowerDefanse
{
    public interface iSelectable
    {
        GameObject Obj { get; }
        bool EnableClick { get; set; }
        Transform Position { get; }
        string Name { get; }
        iSelectable Selected();
    }
}
