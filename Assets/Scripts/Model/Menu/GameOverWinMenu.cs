using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefanse
{
    public class GameOverWinMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverMenu;
        [SerializeField] private GameObject _winMenu;
        [SerializeField] private GameObject _selectLevelMenu;
        [SerializeField] private Button _gameOverBut;
        [SerializeField] private Button _winBut;

        private void Start()
        {
            _gameOverBut.onClick.AddListener(GameOverBut);
            _winBut.onClick.AddListener(WinBut);
        }

        private void WinBut()
        {
            GameProfile.LevelWin = false;
            Destroy(GameProfile.LevelObj, 1);

            if (GameProfile.DefenseObj.Count > 0)
            {
                for (int i = 0; i < GameProfile.DefenseObj.Count; i++)
                {
                    Destroy(GameProfile.DefenseObj[i], 1);
                }
                GameProfile.DefenseObj.Clear();
            }

            if(GameProfile.Enemys.Count > 0)
            {
                for (int i = 0; i < GameProfile.Enemys.Count; i++)
                {
                    Destroy(GameProfile.Enemys[i].GameObject, 1);
                }
            }

            _selectLevelMenu.SetActive(true);
            _winMenu.SetActive(false);
        }

        private void GameOverBut()
        {
            GameProfile.GameOver = false;
            Destroy(GameProfile.LevelObj, 1);

            if(GameProfile.DefenseObj.Count > 0)
            {
                for (int i = 0; i < GameProfile.DefenseObj.Count; i++)
                {
                    Destroy(GameProfile.DefenseObj[i], 1);
                }
                GameProfile.DefenseObj.Clear();
            }

            if (GameProfile.Enemys.Count > 0)
            {
                for (int i = 0; i < GameProfile.Enemys.Count; i++)
                {
                    Destroy(GameProfile.Enemys[i].GameObject, 1);
                }
            }

            _selectLevelMenu.SetActive(true);
            _gameOverMenu.SetActive(false);
        }

        private void Update()
        {
            if (GameProfile.GameOver) _gameOverMenu.SetActive(true);
            if (GameProfile.LevelWin) _winMenu.SetActive(true);
        }
    }
}


