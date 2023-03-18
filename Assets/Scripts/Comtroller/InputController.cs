using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace TowerDefanse
{
    public class InputController : MonoBehaviour
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
                if (GameProfile.FlagFindSelect.Value) GameProfile.FlagFindSelect.Value = false;
                return;
            }
            var mainBuilding = hits
            .Select(hit => hit.collider.GetComponentInParent<iSelectable>())
            .Where(c => c != null)
            .Where(c => c.EnableClick == true)
            .FirstOrDefault();
            if (mainBuilding != default)
            {
                if (GameProfile.FlagFindSelect.Value) 
                { 
                    GameProfile.FlagFindSelect.Value = false; 
                }
                else
                {
                    var aaa = mainBuilding.Selected();

                    if (aaa.EnableClick)
                    {
                        GameProfile.SelectedMenu = mainBuilding;
                        GameProfile.MenuPosition = new Vector3(aaa.Position.position.x, 1, aaa.Position.position.z);
                        GameProfile.MenuName = aaa.Name;
                        GameProfile.FlagFindSelect.Value = true;
                    }
                }
            }
            else
            {
                if (GameProfile.FlagFindSelect.Value) GameProfile.FlagFindSelect.Value = false;
            }
        }
    }
}


