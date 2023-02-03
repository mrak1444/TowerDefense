using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class CheckpointModel : MonoBehaviour, iCheckpoint
    {
        [SerializeField] private GameObject _nextTarget;
        [SerializeField] private string _nameTraget;

        public iCheckpoint NextTarget => _nextTarget.GetComponent<iCheckpoint>();
        public string NameTarget => _nameTraget;
        public Transform ThisTarget => transform;
    }
}


