using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerDefanse
{
    public class TestSelect : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private void Update()
        {
            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }
            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
            if (hits.Length == 0)
            {
                return;
            }
            var mainBuilding = hits
            .Select(hit => hit.collider.GetComponentInParent<iSelectable>())
            .Where(c => c != null)
            .FirstOrDefault();
            if (mainBuilding == default)
            {
                return;
            }
            Debug.Log(mainBuilding.Selected().Position.position);
        }
    }
}


