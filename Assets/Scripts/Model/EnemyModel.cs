using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class EnemyModel : MonoBehaviour, iEnemy
    {
        [SerializeField] private string _nameEnemy = "Infantry"; //��� �����
        [SerializeField] private float _shotPower = 1f; //���� ��������
        [SerializeField] private float _shotRange = 2f; //��������� �������� � ��������� ���������� ����
        [SerializeField] private float _timeShots = 1f; //����� ����� ����������
        [SerializeField] private float _speedEnemy = 1f; //������� ����� 
        [SerializeField] private int _hp = 3; //HP

        private iTower _tower;
        private iCheckpoint _targetCheckpoint;
        private bool _move = true;
        private bool _fire = false;

        public string NameEnemy => _nameEnemy; //��� �����
        public float ShotPower => _shotPower; //���� ��������
        public float ShotRange => _shotRange; //��������� �������� � ��������� ���������� ����
        public float TimeShots => _timeShots; //����� ����� ����������
        public float SpeedEnemy => _speedEnemy; //������� ����� 
        public int Hp { get => _hp; set => _hp = value; }//HP
        public Transform TransformEnemy => transform;
        public iCheckpoint TargetCheckpoint { get => _targetCheckpoint; set => _targetCheckpoint = value; }
        public iTower Tower { get => _tower; set => _tower = value; }

        private void Fire()
        {

        }

        private void Update()
        {
            if (_move)
            {
                var step = _speedEnemy * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, _targetCheckpoint.ThisTarget.position, step);
            }

            if (_fire) Fire();

            if (Vector3.Distance(transform.position, _tower.TowerPosition.position) < 2f) //��������, ����������� ������� �����, ������� �������� �� �� �����, ��������� ������ � �����
            {
                _move = false;
                _fire = true;
            }

            if (Vector3.Distance(transform.position, _targetCheckpoint.ThisTarget.position) < 0.1f)
            {
                _targetCheckpoint = _targetCheckpoint.NextTarget;
            }

            if(_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}


