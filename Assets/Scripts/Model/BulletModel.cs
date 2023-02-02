using UnityEngine;

namespace TowerDefanse

{
    internal sealed class BulletModel : IAmmunition
    {
        public Rigidbody BulletInstance { get; }
        public float TimeToDestroy { get; }

        public BulletModel(Rigidbody bulletInstance, float timeToDestroy)
        {
            BulletInstance = bulletInstance;
            TimeToDestroy = timeToDestroy;
        }
    }
}