using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Game Systems/Player/Interact
[AddComponentMenu("Game Systems/Player/Interact")]
public class Interact : MonoBehaviour
{
    #region Update
    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Ray _ray;
            _ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f));
            RaycastHit _hitInfo;
            if (Physics.Raycast(_ray, out _hitInfo, 10f))
            {

                #region NPC tag
                if (_hitInfo.transform.tag == "NPC")
                {
                    Debug.Log("NPC");
                }           
                #endregion
                #region Item
                if (_hitInfo.transform.tag == "Item")
                {
                    Debug.Log("Item");
                }             
                #endregion
            }
                
        }
              
    }
        
    #endregion
}






