using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {
    NavMeshAgent playerAgent;

    //initiate the nav mesh agent
	void Start () {
        playerAgent = GetComponent<NavMeshAgent>();
	}
	
	void Update () {

        //interacts with object on click, prevents clicking through objects
		if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }

	}

    void GetInteraction()
    {
        //this ray will be sent from the camera to the point where the cursor is
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //this is returned after casting the ray
        RaycastHit interactionInfo;

        //if an object is hit
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            //store the object's info
            GameObject interactedObject = interactionInfo.collider.gameObject;

            if(interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.stoppingDistance = 0;

                //navigate the player to the point of interaction
                playerAgent.destination = interactionInfo.point;
            }

        }
    }
}
