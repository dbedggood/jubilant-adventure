using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

    public NavMeshAgent playerAgent;

    //moves player to interactable object
    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        //this instance of playerAgent on the interactable is used
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 2;
        playerAgent.destination = this.transform.position;

        Interact();
    }

	public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
