using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class CheckpointModel : MonoBehaviour, iCheckpoint
    {
        [SerializeField] private GameObject _nextTarget;

        public iCheckpoint NextTarget => _nextTarget.GetComponent<iCheckpoint>();
        public Transform ThisTarget => transform;
    }
}


