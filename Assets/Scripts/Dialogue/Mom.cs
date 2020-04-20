using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mom : MonoBehaviour {

    public Dialogue dialogue;
    public Animator animator;

    private bool hasTalked;
    private bool startCutscene;

    private void Start() {
        hasTalked = false;
        startCutscene = false;
        animator.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            if (!DialogueManager.Instance.IsTalking) {
                DialogueManager.Instance.StartDialogue(dialogue);
                hasTalked = true;
            }
        }
    }

    private void Update() {
        if (!DialogueManager.Instance.IsTalking && hasTalked && !startCutscene) {
            PlayerInput input = Player.Instance.GetComponent<PlayerInput>();
            input.CanUseInputs = false;
            startCutscene = true;
            animator.enabled = true;
            StartCoroutine(StartTransition());
        }
    }

    IEnumerator StartTransition() {
        yield return new WaitForSeconds(4.7f);
        SceneManager.LoadScene("credits");
    }

}
