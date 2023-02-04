using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class CheckpointModel : MonoBehaviour, iCheckpoint, iTarget
    {
        [SerializeField] private GameObject _nextTarget;
        [SerializeField] private string _nameTraget;

        public iCheckpoint NextTarget => _nextTarget.GetComponent<iCheckpoint>();
        public string NameTarget => _nameTraget;
        public Transform TargetTransform => transform;
        public int Hp { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public iTarget itarget => throw new System.NotImplementedException();
    }
}


