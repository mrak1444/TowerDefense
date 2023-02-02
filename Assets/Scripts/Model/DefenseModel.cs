using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class DefenseModel : MonoBehaviour, iDefense
    {
        private string _nameDefense = "machine gun turret"; //имя башни
        private float _shotPower = 1f; //сила выстрела
        private float _shotRange = 2f; //дальность выстрале и дальность нахождения цели
        private float _timeShots = 1f; //время между выстрелами
        private List<iEnemy> _enemys = new List<iEnemy>();

        public string NameDefense => _nameDefense; //имя врага
        public float ShotPower => _shotPower; //сила выстрела
        public float ShotRange => _shotRange; //дальность выстрале и дальность нахождения цели
        public float TimeShots => _timeShots; //время между выстрелами
        public List<iEnemy> Enemys => _enemys;
        public Transform TransformDefense => transform;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemys.Add(other.GetComponent<iEnemy>());
            }
        }

        private void Fire()
        {

        }  //убрать в контролер

        private void LookAt()
        {
            if (_enemys.Count > 0)
            {
                transform.LookAt(_enemys[0].TransformEnemy);
            }
            else
            {
                transform.LookAt(transform.forward);
            }

        }  //убрать в контролер

        private void Update()
        {
            LookAt();
            Fire();
        }  //убрать в контролер
    }
}


