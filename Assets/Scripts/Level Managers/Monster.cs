using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IInteractable {
    public Dialogue defaultDialogue;
    public Dialogue feedOnceDialogue;
    public Dialogue feedTwiceDialogue;

    private Dialogue activeDialogue;

    private void Start() {
        activeDialogue = defaultDialogue;
    }
    public void OnInteract() {
        activeDialogue = defaultDialogue;
        Feed();
        if (!DialogueManager.Instance.IsTalking) {
            DialogueManager.Instance.StartDialogue(activeDialogue);
        }
        
    }

    void Feed() {
        ProgressManager progress = ProgressManager.Instance;
        if (progress.BossOneBeaten && !progress.BossTwoBeaten && progress.NumTimesFed == 0) {
            progress.NumTimesFed = 1;
            activeDialogue = feedOnceDialogue;
        }
        else if (progress.BossOneBeaten && progress.BossTwoBeaten && progress.NumTimesFed == 1) {
            progress.NumTimesFed = 2;
            activeDialogue = feedTwiceDialogue;
        }
    }
}
