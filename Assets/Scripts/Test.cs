using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private GameObject ass;
        
        void Update()
        {
            var a = ass.GetComponent<iEnemy>().TransformEnemy;
            Debug.Log(a.position);
        }
    }

}

