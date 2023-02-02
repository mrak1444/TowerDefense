using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class EnemyModel : MonoBehaviour, iEnemy
    {
        [SerializeField] private string _nameEnemy = "Infantry"; //имя башни
        [SerializeField] private float _shotPower = 1f; //сила выстрела
        [SerializeField] private float _shotRange = 2f; //дальность выстрале и дальность нахождения цели
        [SerializeField] private float _timeShots = 1f; //время между выстрелами
        [SerializeField] private float _speedEnemy = 1f; //скороть врага 
        [SerializeField] private int _hp = 10; //HP

        public string NameEnemy => _nameEnemy; //имя врага
        public float ShotPower => _shotPower; //сила выстрела
        public float ShotRange => _shotRange; //дальность выстрале и дальность нахождения цели
        public float TimeShots => _timeShots; //время между выстрелами
        public float SpeedEnemy => _speedEnemy; //скороть врага 
        public int Hp => _hp; //HP
        public Transform TransformEnemy => transform;

        public void Move(Transform target)
        {
            var step = _speedEnemy * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }  //убрать в контролер
    }
}


