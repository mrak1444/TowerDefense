using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefanse
{
    public class MenuBuildController : MonoBehaviour
    {
        [SerializeField] private Button _butExiteMenuBuild;
        [SerializeField] private GameObject _tower;

        private DefenseModel _obj;

        private void Start()
        {
            _butExiteMenuBuild.onClick.AddListener(ButExiteMenuBuild);
            _obj = _tower.GetComponent<DefenseModel>();
        }

        private void ButExiteMenuBuild()
        {
            if (GameProfile.MoneyInLevel.Value >= _obj.PriceInstantiate)
            {
                StartCoroutine(ChangeFlag());
            }
        }

        private IEnumerator ChangeFlag()
        {
            GameProfile.MoneyInLevel.Value -= _obj.PriceInstantiate;
            Instantiate(_tower, GameProfile.MenuPosition, Quaternion.identity);
            GameProfile.SelectedMenu.EnableClick = false;
            yield return new WaitForSeconds(0.1f);
            GameProfile.FlagFindSelect.Value = false;
        }
    }
}


