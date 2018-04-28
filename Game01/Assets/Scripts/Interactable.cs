using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    [HideInInspector]

    public NavMeshAgent playerAgent;

    //once interacted, this is set to true to stop interacting with the object every frame
    private bool hasInteracted;

    //moves player to interactable object
    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        //this instance of playerAgent on the interactable is used
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 2.5f;
        playerAgent.destination = this.transform.position;

    }

    private void Update()
    {
        //check for playerAgent, and if a path in the process of being computed but not yet ready
        if (playerAgent != null && !playerAgent.pathPending && !hasInteracted)
        {
            //if remaining distance is within stopping distance, interact
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
