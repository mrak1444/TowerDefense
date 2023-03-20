using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefanse
{
    public class MenuActivateController : MonoBehaviour
    {
        [SerializeField] GameObject _menuBuildActive;
        [SerializeField] GameObject _menuBuildPosition;
        [SerializeField] GameObject _menuDefenceActive;
        [SerializeField] GameObject _menuDefencePosition;

        private void Start()
        {
            GameProfile.FlagFindSelect.SubscribeOnChange(MenuActive);
        }

        private void OnDestroy()
        {
            GameProfile.FlagFindSelect.UnSubscriptionOnChange(MenuActive);
        }

        private void MenuActive(bool obj)
        {
            switch (GameProfile.MenuName)
            {
                case "FloorBuild":
                    _menuBuildActive.SetActive(obj);
                    if (obj) _menuBuildPosition.transform.position = new Vector3(GameProfile.MenuPosition.x, GameProfile.MenuPosition.y+2, GameProfile.MenuPosition.z);
                    break;

                case "MachineGunTurret":
                    _menuDefenceActive.SetActive(obj);
                    if (obj) _menuDefencePosition.transform.position = new Vector3(GameProfile.MenuPosition.x, GameProfile.MenuPosition.y + 2, GameProfile.MenuPosition.z);
                    break;
            }
        }
    }
}


