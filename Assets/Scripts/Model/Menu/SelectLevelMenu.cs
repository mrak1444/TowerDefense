using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefanse
{
    public class SelectLevelMenu : MonoBehaviour
    {
        [SerializeField] private Button[] _butLevel;
        [SerializeField] private GameObject[] _objLevel;
        [SerializeField] private GameObject _objMenuLevel;
        [SerializeField] private GameObject _camera;

        private void Start()
        {
            for (int i = 0; i < _butLevel.Length; i++)
            {
                var ii = i;
                _butLevel[i].onClick.AddListener(() => ButLevel(ii));
            }
        }

        private void ButLevel(int ii)
        {
            if(ii < _objLevel.Length)
            {
                _objMenuLevel.SetActive(false);
                _camera.SetActive(false);
                GameProfile.LevelObj = Instantiate(_objLevel[ii]);
            }
        }
    }
}


