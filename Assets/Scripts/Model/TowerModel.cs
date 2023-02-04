using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class TowerModel : MonoBehaviour, iTower
    {
        [SerializeField] private int _hp = 50;

        public Transform TowerPosition => transform;
        public int HP { get => _hp; set => _hp = value; }
    }
}


