using System.Collections;
using UnityEngine;

public class Interact : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Ray interactionRay;
            interactionRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(interactionRay, out hitInfo, 10))
            {
                //switch version
                switch (hitInfo.collider.tag)
                {
                    case "NPC":
                        Debug.Log("Talk to NPC");
                    break;
                    case "Item":
                        Debug.Log("Pick up Item");
                    break;
                }
                //if version
                //if (hitInfo.collider.CompareTag("NPC"))
                //{
                //    Debug.Log("Hit NPC");
                //
                //    if (hitInfo.collider.tag == "Item")
                //    {
                //        Debug.Log("Hit Item");
                //    }
                //}
            }
        }
    }
}
