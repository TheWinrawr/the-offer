using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class BossRoomOne : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public Transform spawnPoint;
    public Transform foods;

    public Dialogue dialogue;

    public int NumFoodGotten { get; set; }


    private void Start() {
        NumFoodGotten = 0;
        if (ProgressManager.Instance.BossOneBeaten) {
            foods.gameObject.SetActive(false);
        }
    }

    public void Reset() {
        StartCoroutine(ResetLevel());
    }

    IEnumerator ResetLevel() {
        yield return new WaitForSeconds(1f);
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if (!ProgressManager.Instance.BossOneBeaten) {
            foreach (Transform food in foods) {
                food.gameObject.SetActive(true);
            }
            NumFoodGotten = 0;
        }

        Player.Instance.transform.position = spawnPoint.position;
        Player.Instance.Revive();

        transition.SetTrigger("End");
    }

    public void PickupItem() {
        NumFoodGotten++;
        if (NumFoodGotten >= 3) {
            ProgressManager.Instance.BossOneBeaten = true;
            DialogueManager.Instance.StartDialogue(dialogue);
        }
    }
}
