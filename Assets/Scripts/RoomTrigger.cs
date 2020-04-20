using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTrigger : MonoBehaviour {
    public Animator transition;
    public string sceneName;
    public float transitionTime = 1f;

    private bool hasEntered;

    private void Start() {
        hasEntered = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player") && !hasEntered) {
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
