using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class FloorForBuildsModel : MonoBehaviour, iSelectable
    {
        [SerializeField] private Material _material;
        [SerializeField] private Material _materialSelected;
        [SerializeField] private string _name;

        private Renderer _renderer;
        private iSelectable _selec;
        private bool _enableClick = true;

        public Transform Position => transform;
        public string Name => _name;
        public bool EnableClick { get => _enableClick; set => _enableClick = value; }
        public GameObject Obj => gameObject;

        private void Start()
        {
            _selec = GetComponent<iSelectable>();
            _renderer = GetComponent<Renderer>();
            GameProfile.FlagFindSelect.SubscribeOnChange(MenuActive);
        }

        private void OnDestroy()
        {
            GameProfile.FlagFindSelect.UnSubscriptionOnChange(MenuActive);
        }

        private void MenuActive(bool obj)
        {
            if(!obj) _renderer.material = _material;
        }

        public iSelectable Selected()
        {
            /*if (GameProfile.FlagFindSelect.Value)
            {
                
            }*/

            _renderer.material = _materialSelected;

            return _selec;
        }
    }
}


