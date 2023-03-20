using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class EnemyModel : MonoBehaviour, iEnemy, iTarget
    {
        [SerializeField] private string _nameEnemy = "Infantry"; //имя башни
        [SerializeField] private int _shotPower = 1; //сила выстрела
        [SerializeField] private float _timeShots = 1f; //время между выстрелами
        [SerializeField] private float _speedEnemy = 1f; //скороть врага 
        [SerializeField] private int _hp = 3; //HP
        [SerializeField] private Transform _startFirePosition;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private int _priceKill;

        private iTarget _tower;
        private iCheckpoint _targetCheckpoint;
        private bool _move = true;
        private bool _fire = false;
        private int _numInBase;
        private Transform _transform;

        public GameObject GameObject => gameObject;
        public string NameEnemy => _nameEnemy; //имя врага
        public int Hp { get => _hp; set => _hp = value; }//HP
        public Transform TargetTransform => transform;
        public iCheckpoint TargetCheckpoint { get => _targetCheckpoint; set => _targetCheckpoint = value; }
        public iTarget Tower { get => _tower; set => _tower = value; }
        public int NumInBase { get => _numInBase; set => _numInBase = value; }

        private IEnumerator Fire()
        {
            while (_tower != null)
            {
                var bullet = Instantiate(_bullet, _startFirePosition.position, transform.rotation).GetComponent<IAmmunition>();  //откорректировать
                bullet.ShotPower = _shotPower;
                bullet.Target = _tower;
                yield return new WaitForSeconds(_timeShots);
            }
                
        }

        private void LookAt()
        {
            if (_move)
            {
                transform.LookAt(_transform);
            }
            else
            {
                if (_tower != null)
                {
                    transform.LookAt(_tower.TargetTransform);
                }
                else
                {
                    transform.rotation = Quaternion.identity;
                }
            }
        }

        private void Update()
        {
            try
            {
                var a = _tower.TargetTransform;
            }
            catch  //MissingReferenceException e
            {
                _tower = null;
            }

            try
            {
                _transform = _targetCheckpoint.ThisTarget;
            }
            catch
            {

            }


            //Debug.Log($"fff {Vector3.Distance(transform.position, _tower.TargetTransform.position)}");

            LookAt();

            if (_move)
            {
                var step = _speedEnemy * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, _targetCheckpoint.ThisTarget.position, step);
            }

            if (_fire) 
            {
                _fire = false;
                StartCoroutine(Fire()); 
            }

            /*try
            {
                if (Vector3.Distance(transform.position, _tower.TargetTransform.position) < 6f && _move) //дописать, реализовать главную башню, сделать выстрелы по гл башне, отнимание жизней у башни
                {
                    _move = false;
                    _fire = true;
                }
            }
            catch (MissingReferenceException e)
            {
                _move = false;
                _fire = false;
                _tower = null;
            }*/

            if(_tower != null)
            {
                if (Vector3.Distance(transform.position, _tower.TargetTransform.position) < 6f && _move) //дописать, реализовать главную башню, сделать выстрелы по гл башне, отнимание жизней у башни
                {
                    _move = false;
                    _fire = true;
                }
            }
            
            if (Vector3.Distance(transform.position, _targetCheckpoint.ThisTarget.position) < 0.1f && _move)
            {
                _targetCheckpoint = _targetCheckpoint.NextTarget;
            }

            if(_hp <= 0)
            {
                GameProfile.MoneyInLevel.Value += _priceKill;
                Destroy(gameObject, 3f);
                //transform.position = new Vector3(transform.position.x, -100, transform.position.z);
                gameObject.SetActive(false);
            }
        }
    }
}


