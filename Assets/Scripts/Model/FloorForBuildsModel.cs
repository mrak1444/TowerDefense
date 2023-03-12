using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class FloorForBuildsModel : MonoBehaviour, iSelectable
    {
        [SerializeField] private Material _material;
        [SerializeField] private Material _materialSelected;

        private Renderer _renderer;
        private iSelectable _selec;

        public Transform Position => transform;

        private void Start()
        {
            _selec = GetComponent<iSelectable>();
            _renderer = GetComponent<Renderer>();
        }

        public iSelectable Selected()
        {
            _renderer.material = _materialSelected;
            return _selec;
        }
    }
}


