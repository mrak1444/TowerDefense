using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class TowerModel : MonoBehaviour, iTarget
    {
        [SerializeField] private int _hp = 5;

        public Transform TargetTransform => transform;
        public int Hp { get => _hp; set => _hp = value; }
        public GameObject GameObject => gameObject;

        private void Update()
        {
            if (_hp <= 0)
            {
                GameProfile.GameOver = true;
                Debug.Log("GameOver!");
                Destroy(gameObject, 1f);
                //transform.position = new Vector3(100, 100, 100);
                gameObject.SetActive(false);
            }
        }
    }
}


