using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class DefenseModel : MonoBehaviour, iDefense
    {
        [SerializeField] private Transform _startFirePosition;
        [SerializeField] private GameObject _bullet;

        private string _nameDefense = "machine gun turret"; //имя башни
        private int _shotPower = 1; //сила выстрела
        private float _shotRange = 5f; //дальность выстрале и дальность нахождения цели
        private float _timeShots = 1f; //время между выстрелами
        private List<iTarget> _enemy = null;
        private bool _flag = true;

        public string NameDefense => _nameDefense; //имя врага
        public Transform TransformDefense => transform;

        private void FindNearestEnemy()
        {
            for (int i = 0; i < GameData.Enemys.Count; i++)
            {
                if (Vector3.Distance(transform.position, GameData.Enemys[i].TargetTransform.position) <= _shotRange)
                {
                    _enemy.Add(GameData.Enemys[i]);
                }
            }

            for (int i = 0; i < _enemy.Count; i++)
            {
                if (Vector3.Distance(transform.position, _enemy[i].TargetTransform.position) > _shotRange)
                {
                    _enemy.Remove(_enemy[i]);
                }
            }
        }

        private void LookAt()
        {
            if (_enemy.Count > 0)
            {
                transform.LookAt(_enemy[0].TargetTransform);
            }
            else
            {
                transform.LookAt(transform.forward);
            }

        }

        private IEnumerator Fire()
        {
            while (_enemy.Count > 0)
            {
                var bullet = Instantiate(_bullet, _startFirePosition.position, transform.rotation).GetComponent<IAmmunition>();  //откорректировать
                bullet.ShotPower = _shotPower;
                bullet.Target = _enemy[0];
                yield return new WaitForSeconds(_timeShots);
            }

            _flag = true;
        }

        

        private void Update()
        {
            FindNearestEnemy();

            LookAt();

            if (_enemy.Count > 0 && _flag)
            {
                _flag = false;
                StartCoroutine(Fire());
            }
        }
    }
}


