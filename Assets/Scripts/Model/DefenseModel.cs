using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public abstract class DefenseModel : MonoBehaviour, iDefense
    {
        private string _nameDefense; //имя башни
        private float _shotPower; //сила выстрела
        private float _shotRange; //дальность выстрале и дальность нахождения цели
        private float _timeShots; //время между выстрелами

        public DefenseModel(string nameDefense, float shotPower, float shotRange, float timeShots)
        {
            this._nameDefense = nameDefense;
            this._shotPower = shotPower;
            this._shotRange = shotRange;
            this._timeShots = timeShots;
        }
    }
}


