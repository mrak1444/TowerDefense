using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    [System.Serializable]
    public struct Enemys
    {
        public GameObject[] Enemy;
    }

    public class StartTest : MonoBehaviour
    {
        [SerializeField] private Enemys[] _waves;
        [SerializeField] private GameObject _startCheckpoint;
        [SerializeField] private GameObject _base;

        private int _waveNum = 0;
        private bool _flag = false;

        private void Start()
        {
            StartCoroutine(inst(_waveNum));
        }

        private IEnumerator inst(int waveNum)
        {
            _flag = false;

            for (int i = 0; i < _waves[waveNum].Enemy.Length; i++)
            {
                var a = Instantiate(_waves[waveNum].Enemy[i], transform.position, Quaternion.identity).GetComponent<iEnemy>();
                a.TargetCheckpoint = _startCheckpoint.GetComponent<iCheckpoint>();
                a.Tower = _base.GetComponent<iTarget>();
                GameData.Enemys.Add((iTarget)a);
                yield return new WaitForSeconds(1.5f);
            }
            _flag = true;
            _waveNum++;
        }

        private void Update()
        {
            if(GameData.Enemys.Count <= 0 && _flag)
            {
                if((_waveNum) < _waves.Length)
                {
                    StartCoroutine(inst(_waveNum));
                }
            }

            for (int i = 0; i < GameData.Enemys.Count; i++)
            {
                if (GameData.Enemys[i].Hp <= 0) GameData.Enemys.RemoveAt(i);
            }
        }
    }
}


