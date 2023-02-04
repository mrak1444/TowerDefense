using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class EnemyModel : MonoBehaviour, iEnemy, iTarget
    {
        [SerializeField] private string _nameEnemy = "Infantry"; //��� �����
        [SerializeField] private int _shotPower = 1; //���� ��������
        [SerializeField] private float _shotRange = 2f; //��������� �������� � ��������� ���������� ����
        [SerializeField] private float _timeShots = 1f; //����� ����� ����������
        [SerializeField] private float _speedEnemy = 1f; //������� ����� 
        [SerializeField] private int _hp = 3; //HP
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _startFirePosition;

        private iCheckpoint _target;
        private bool _move = true;

        public string NameEnemy => _nameEnemy; //��� �����
        public int ShotPower => _shotPower; //���� ��������
        public float ShotRange => _shotRange; //��������� �������� � ��������� ���������� ����
        public float TimeShots => _timeShots; //����� ����� ����������
        public float SpeedEnemy => _speedEnemy; //������� ����� 
        public int Hp { get => _hp; set => _hp = value; }//HP
        public Transform TargetTransform => transform;
        public iCheckpoint Target { get => _target; set => _target = value; }

        private IEnumerator Fire()
        {
            var bullet = Instantiate(_bullet, _startFirePosition.position, transform.rotation).GetComponent<IAmmunition>();  //����������������
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
                if (_target.NameTarget == "Tower")  //��������, ����������� ������� �����, ������� �������� �� �� �����, ��������� ������ � �����
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


