using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class EnemyModel : MonoBehaviour, iEnemy
    {
        public abstract string NameDefense { get; } //��� �����
        public abstract float ShotPower { get; } //���� ��������
        public abstract float ShotRange { get; } //��������� �������� � ��������� ���������� ����
        public abstract float TimeShots { get; } //����� ����� ����������
        public abstract float SpeedEnemy { get; } //������� ����� 
        public abstract int Hp { get; } //HP
        public Transform TransformEnemy => transform;

        public abstract void Move(Transform target);
    }
}


