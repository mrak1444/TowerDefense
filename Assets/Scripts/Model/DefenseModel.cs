using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class DefenseModel : MonoBehaviour, iDefense
    {
        private string _nameDefense = "machine gun turret"; //��� �����
        private float _shotPower = 1f; //���� ��������
        private float _shotRange = 2f; //��������� �������� � ��������� ���������� ����
        private float _timeShots = 1f; //����� ����� ����������
        private List<iEnemy> _enemys = new List<iEnemy>();

        public string NameDefense => _nameDefense; //��� �����
        public float ShotPower => _shotPower; //���� ��������
        public float ShotRange => _shotRange; //��������� �������� � ��������� ���������� ����
        public float TimeShots => _timeShots; //����� ����� ����������
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

        }  //������ � ���������

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

        }  //������ � ���������

        private void Update()
        {
            LookAt();
            Fire();
        }  //������ � ���������
    }
}


