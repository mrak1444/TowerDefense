using System.Collections;
using System;
using UnityEngine;

namespace TowerDefanse
{
    [Serializable]
    public struct Enemys
    {
        public GameObject[] Enemy;
    }

    public class LevelModel : MonoBehaviour
    {
        [SerializeField] private Enemys[] _waves;
        [SerializeField] private GameObject[] _startCheckpoint;
        [SerializeField] private GameObject[] _nextCheckpoint;
        [SerializeField] private GameObject _base;
        [SerializeField] private int _startMoney;

        private int _waveNum = 0;
        private bool _flag = false;
        private int _wayStartNum = 0;
        private int _wayNextNum = 0;

        private void Start()
        {
            GameProfile.WavesAll = _waves.Length;
            if(!GameProfile.GameOver || !GameProfile.LevelWin) StartCoroutine(RunInst(_waveNum));
            
            StartCoroutine(AddMeney());
        }

        private IEnumerator AddMeney()
        {
            yield return new WaitForSeconds(0.05f);
            GameProfile.MoneyInLevel.Value = _startMoney;
        }

        private IEnumerator RunInst(int waveNum)
        {
            yield return new WaitForSeconds(2f);
            StartCoroutine(inst(waveNum));
        }

        private IEnumerator inst(int waveNum)
        {
            //Debug.Log(waveNum + 1);
            GameProfile.WaveNow.Value = waveNum + 1;

            _flag = false;

            for (int i = 0; i < _waves[waveNum].Enemy.Length; i++)
            {
                var a = Instantiate(_waves[waveNum].Enemy[i], _startCheckpoint[_wayStartNum].transform.position, Quaternion.identity).GetComponent<iEnemy>();
                a.TargetCheckpoint = _nextCheckpoint[_wayNextNum].GetComponent<iCheckpoint>();
                a.Tower = _base.GetComponent<iTarget>();
                GameProfile.Enemys.Add((iTarget)a);

                _wayStartNum++;
                _wayNextNum++;

                if (_wayStartNum >= _startCheckpoint.Length) _wayStartNum = 0;
                if (_wayNextNum >= _nextCheckpoint.Length) _wayNextNum = 0;
                
                yield return new WaitForSeconds(1.5f);
            }
            _flag = true;
            _waveNum++;
        }

        private void Update()
        {
            if (GameProfile.Enemys.Count <= 0 && _flag)
            {
                if (_waveNum < _waves.Length)
                {
                    StartCoroutine(inst(_waveNum));
                }
                else if (_waveNum >= _waves.Length)
                {
                    Debug.Log("Win!");
                    GameProfile.LevelWin = true;
                }
            }

            for (int i = 0; i < GameProfile.Enemys.Count; i++)
            {
                if (GameProfile.Enemys[i].Hp <= 0) GameProfile.Enemys.RemoveAt(i);
            }
        }
    }
}