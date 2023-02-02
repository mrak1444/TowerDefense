using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class Infantry_1_Version_1_Model : MonoBehaviour, iEnemy
    {
        [SerializeField] private string _nameDefense = "Infantry"; //��� �����
        [SerializeField] private float _shotPower = 1f; //���� ��������
        [SerializeField] private float _shotRange = 2f; //��������� �������� � ��������� ���������� ����
        [SerializeField] private float _timeShots = 1f; //����� ����� ����������
        [SerializeField] private float _speedEnemy = 1f; //������� ����� 
        [SerializeField] private int _hp = 10; //HP

        public string NameDefense => _nameDefense; //��� �����
        public float ShotPower => _shotPower; //���� ��������
        public float ShotRange => _shotRange; //��������� �������� � ��������� ���������� ����
        public float TimeShots => _timeShots; //����� ����� ����������
        public float SpeedEnemy => _speedEnemy; //������� ����� 
        public int Hp => _hp; //HP
        public Transform TransformEnemy => transform;

        public void Move(Transform target)
        {
            var step = _speedEnemy * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}


