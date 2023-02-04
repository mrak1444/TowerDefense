using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public interface iDefense  //защита
    {
        string NameDefense { get; }
        Transform TransformDefense { get; }
    }
}


