using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class StartTest : MonoBehaviour
    {
        [SerializeField] private GameObject[] _enemy;
        [SerializeField] private GameObject _startCheckpoint;
        [SerializeField] private GameObject _base;

        private void Start()
        {
            StartCoroutine(inst());
        }

        private IEnumerator inst()
        {
            for (int i = 0; i < _enemy.Length; i++)
            {
                var a = Instantiate(_enemy[i], transform.position, Quaternion.identity).GetComponent<iEnemy>();
                a.TargetCheckpoint = _startCheckpoint.GetComponent<iCheckpoint>();
                a.Tower = _base.GetComponent<iTarget>();
                GameData.Enemys.Add((iTarget)a);
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}


