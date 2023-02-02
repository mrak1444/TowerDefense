using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class EnemyModel : MonoBehaviour, iEnemy
    {
        public abstract string NameDefense { get; } //имя врага
        public abstract float ShotPower { get; } //сила выстрела
        public abstract float ShotRange { get; } //дальность выстрале и дальность нахождения цели
        public abstract float TimeShots { get; } //время между выстрелами
        public abstract float SpeedEnemy { get; } //скороть врага 
        public abstract int Hp { get; } //HP
        public Transform TransformEnemy => transform;

        public abstract void Move(Transform target);
    }
}


