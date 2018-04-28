using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RibCage : ActionItem {

    public string[] dialogue;
    public override void Interact()
    {
        DialogueManager.Instance.AddNewDialogue(dialogue, "Bones");
    }

}
