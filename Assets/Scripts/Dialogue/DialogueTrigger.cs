using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable {

    public Dialogue dialogue;

    public void OnInteract() {
        if (!DialogueManager.Instance.IsTalking) {
            DialogueManager.Instance.StartDialogue(dialogue);

        }
    }
}
