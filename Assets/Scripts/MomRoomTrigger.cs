using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MomRoomTrigger : MonoBehaviour
{
    public Animator transition;
    public string sceneName;
    public float transitionTime = 1f;
    public Dialogue dialogue;

    private bool hasEntered;

    private void Start() {
        hasEntered = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player") && !hasEntered) {
            if (ProgressManager.Instance.NumTimesFed < 2) {
                DialogueManager.Instance.StartDialogue(dialogue);
                return;
            }
            StartCoroutine(LoadLevel());
            hasEntered = true;
        }
    }

    IEnumerator LoadLevel() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
