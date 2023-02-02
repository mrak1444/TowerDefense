using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class Tower_1_Version_2_Model : DefenseModel
    {
        private List<iEnemy> _enemys = new List<iEnemy>();

        public Tower_1_Version_2_Model() : base("machine gun turret", 5f, 2f, 1f) { }

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

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemys.Add(other.GetComponent<iEnemy>());
            }
        }

        private void Update()
        {
            LookAt();
        }
    }
}


