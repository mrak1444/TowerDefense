using UnityEngine;

namespace TowerDefanse

{
    internal sealed class BulletModel : MonoBehaviour, IAmmunition
    {
        [SerializeField] private float _speedBullet = 0.1f;
        [SerializeField] private float _timeToDestroy = 5f;

        private int _shotPower = 1; //сила выстрела
        private iTarget _target;
        private Transform _targetposition;

        public int ShotPower { get => _shotPower; set => _shotPower = value; }
        public iTarget Target { get => _target; set => _target = value; }
        public GameObject Obj { get => gameObject; }

        private void Start()
        {
            Destroy(gameObject, _timeToDestroy);

            _targetposition = _target.TargetTransform;
        }

        private void Update()
        {
            var step = _speedBullet * Time.deltaTime; // calculate distance to move
            try
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetposition.position, step);

                if (Vector3.Distance(transform.position, _targetposition.position) < 0.1f)
                {
                    _target.Hp -= _shotPower;
                    Destroy(gameObject);
                }
            }
            catch (MissingReferenceException e)
            {
                Destroy(gameObject);
            }
        }
    }
}