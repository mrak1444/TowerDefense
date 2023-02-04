using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class EnemyModel : MonoBehaviour, iEnemy, iTarget
    {
        [SerializeField] private string _nameEnemy = "Infantry"; //имя башни
        [SerializeField] private int _shotPower = 1; //сила выстрела
        [SerializeField] private float _shotRange = 2f; //дальность выстрале и дальность нахождения цели
        [SerializeField] private float _timeShots = 1f; //время между выстрелами
        [SerializeField] private float _speedEnemy = 1f; //скороть врага 
        [SerializeField] private int _hp = 3; //HP
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _startFirePosition;

        private iCheckpoint _target;
        private bool _move = true;

        public string NameEnemy => _nameEnemy; //имя врага
        public int ShotPower => _shotPower; //сила выстрела
        public float ShotRange => _shotRange; //дальность выстрале и дальность нахождения цели
        public float TimeShots => _timeShots; //время между выстрелами
        public float SpeedEnemy => _speedEnemy; //скороть врага 
        public int Hp { get => _hp; set => _hp = value; }//HP
        public Transform TargetTransform => transform;
        public iCheckpoint Target { get => _target; set => _target = value; }

        private IEnumerator Fire()
        {
            var bullet = Instantiate(_bullet, _startFirePosition.position, transform.rotation).GetComponent<IAmmunition>();  //откорректировать
            bullet.ShotPower = _shotPower;
            //bullet.Target = _enemy[0];
            yield return new WaitForSeconds(_timeShots);
        }

        private void Update()
        {
            if (_move)
            {
                var step = _speedEnemy * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, _target.TargetTransform.position, step);
            }

            if(Vector3.Distance(transform.position, _target.TargetTransform.position) < 2f)
            {
                if (_target.NameTarget == "Tower")  //дописать, реализовать главную башню, сделать выстрелы по гл башне, отнимание жизней у башни
                {
                    _move = false;
                }
            }

            if (Vector3.Distance(transform.position, _target.TargetTransform.position) < 0.1f)
            {
                if(_target.NameTarget == "Checkpoint")
                {
                    _target = _target.NextTarget;
                }
            }

            if(_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}


