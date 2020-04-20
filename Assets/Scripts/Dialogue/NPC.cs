using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour, IInteractable {

    public Dialogue introDialogue1;
    public Dialogue introDialogue2;

    public Dialogue bossOneBeatenDialogue1;
    public Dialogue bossOneBeatenDialogue2;

    public Dialogue petFedOnceDialogue1;
    public Dialogue petFedOnceDialogue2;

    public Dialogue bossTwoBeatenDialogue1;
    public Dialogue bossTwoBeatenDialogue2;

    public Dialogue petFedTwiceDialogue1;
    public Dialogue petFedTwiceDialogue2;

    public Dialogue temporary;

    private Dialogue activeDialogue;

    // Use this for initialization
    void Start() {
        activeDialogue = null;
    }

    void IInteractable.OnInteract() {
        UpdateActiveDialogue();
        if (!DialogueManager.Instance.IsTalking) {
            DialogueManager.Instance.StartDialogue(activeDialogue);
            
        }
    }

    public void UpdateActiveDialogue() {
        ProgressManager progress = ProgressManager.Instance;
        if (!progress.BossOneBeaten) {
            if (activeDialogue == introDialogue1) {
                activeDialogue = introDialogue2;
            }
            else {
                activeDialogue = introDialogue1;
            }
        }

        else if (progress.BossOneBeaten && !progress.BossTwoBeaten) {
            if (progress.NumTimesFed == 0) {
                if (activeDialogue == bossOneBeatenDialogue1) {
                    activeDialogue = bossOneBeatenDialogue2;
                }
                else {
                    activeDialogue = bossOneBeatenDialogue1;
                }
            }
            else if (progress.NumTimesFed == 1) {
                
                if (activeDialogue == petFedOnceDialogue1) {
                    activeDialogue = petFedOnceDialogue2;
                } else {
                    activeDialogue = petFedOnceDialogue1;
                }
                
                //activeDialogue = temporary;
            }
        }

        else if (progress.BossOneBeaten && progress.BossTwoBeaten) {
            if (progress.NumTimesFed == 1) {
                if (activeDialogue == bossTwoBeatenDialogue1) {
                    activeDialogue = bossTwoBeatenDialogue2;
                } else {
                    activeDialogue = bossTwoBeatenDialogue1;
                }
            } else if (progress.NumTimesFed == 2) {
                /*
                if (activeDialogue == petFedTwiceDialogue1) {
                    activeDialogue = petFedTwiceDialogue2;
                } else {
                    activeDialogue = petFedTwiceDialogue1;
                }
                */

                activeDialogue = temporary;
            }
        }
    }
}
