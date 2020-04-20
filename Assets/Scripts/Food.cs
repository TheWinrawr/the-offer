using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    public UnityEvent ItemPicked;

    void IInteractable.OnInteract() {
        if (!DialogueManager.Instance.IsTalking) {
            DialogueManager.Instance.StartDialogue(dialogue);
        }

        ItemPicked.Invoke();
        gameObject.SetActive(false);
    }
}
