using UnityEngine;

namespace TowerDefanse

{
    internal sealed class BulletModel : MonoBehaviour, IAmmunition
    {
        [SerializeField] private float _speedBullet = 0.1f;
        [SerializeField] private float _timeToDestroy = 5f;

        private int _shotPower = 1; //сила выстрела
        private iTarget _target;

        public GameObject Obj => gameObject;
        public float SpeedBullet => _speedBullet;
        public float TimeToDestroy => _timeToDestroy;
        public int ShotPower { get => _shotPower; set => _shotPower = value; }
        public iTarget Target { get => _target; set => _target = value; }

        private void Start()
        {
            Destroy(gameObject, _timeToDestroy);
        }

        private void Update()
        {
            var step = SpeedBullet * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _target.TargetTransform.position, step);

            if(Vector3.Distance(transform.position, _target.TargetTransform.position) < 0.1f)
            {
                _target.Hp -= _shotPower;
                Destroy(gameObject);
            }
        }
    }
}