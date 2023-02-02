using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class DefenseModel : MonoBehaviour, iDefense
    {
        private string _nameDefense; //��� �����
        private float _shotPower; //���� ��������
        private float _shotRange; //��������� �������� � ��������� ���������� ����
        private float _timeShots; //����� ����� ����������

        public DefenseModel(string nameDefense, float shotPower, float shotRange, float timeShots)
        {
            this._nameDefense = nameDefense;
            this._shotPower = shotPower;
            this._shotRange = shotRange;
            this._timeShots = timeShots;
        }
    }
}


