using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TowerDefanse
{
    public class BaseMenuController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _money;
        [SerializeField] private TMP_Text _wave;

        private void Start()
        {
            GameProfile.MoneyInLevel.SubscribeOnChange(AddTextMoney);
            GameProfile.WaveNow.SubscribeOnChange(AddWave);
        }

        private void AddWave(int obj)
        {
            _wave.text = $"{obj.ToString()} / {GameProfile.WavesAll}";
        }

        private void AddTextMoney(int obj)
        {
            _money.text = obj.ToString();
        }
    }
}


