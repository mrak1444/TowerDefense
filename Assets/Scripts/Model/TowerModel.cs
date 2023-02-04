using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class TowerModel : MonoBehaviour, iTarget
    {
        [SerializeField] private int _hp = 50;

        public Transform TargetTransform => transform;
        public int Hp { get => _hp; set => _hp = value; }
    }
}


