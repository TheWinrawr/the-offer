using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBox;
    public GameObject nameBox;
    private TextMeshProUGUI text;
    private TextMeshProUGUI name;

    public static DialogueManager Instance { get; private set; }
    public bool IsTalking { get; private set; }

    private Queue<Sentence> sentences;
    private string currSentence;
    private int currCharPosition;
    private float textSpeed;
    private float timeUntilNextChar;
    private bool canPressSpace;

    private void Awake() {
        if (Instance != null) {
            print("will destroy dialogue");
            Destroy(gameObject);
        }
        Instance = this;

        text = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();
        name = nameBox.GetComponentInChildren<TextMeshProUGUI>();
        dialogueBox.SetActive(false);
        nameBox.SetActive(false);
    }

    private void Start() {
        IsTalking = false;
        canPressSpace = false;
        sentences = new Queue<Sentence>();
    }

    public void StartDialogue(Dialogue dialogue) {
        dialogueBox.SetActive(true);
        nameBox.SetActive(true);
        Time.timeScale = 0f;
        sentences.Clear();
        foreach (Sentence sentence in dialogue.Sentences) {
            sentences.Enqueue(sentence);
        }
        textSpeed = dialogue.TextSpeed;

        IsTalking = true;
        timeUntilNextChar = 0f;
        NextSentence();
    }

    private void Update() {
        if (IsTalking) {
            CheckPlayerInput();
            UpdateCharPosition();
            text.text = currSentence.Substring(0, currCharPosition);
            canPressSpace = true;
        }
    }

    private void CheckPlayerInput() {
        if (Input.GetKeyDown(KeyCode.Space) && canPressSpace) {
            if (currCharPosition >= currSentence.Length) {
                NextSentence();
            } else {
                currCharPosition = currSentence.Length;
            }
        }
    }

    private void UpdateCharPosition() {
        if (currCharPosition < currSentence.Length) {
            if (timeUntilNextChar <= 0) {
                timeUntilNextChar = textSpeed;
                currCharPosition++;
            } else {
                timeUntilNextChar -= Time.unscaledDeltaTime;
            }
        }
    }

    private void NextSentence() {
        if (sentences.Count <= 0) {
            EndDialogue();
            return;
        }
        Sentence nextSentence = sentences.Dequeue();
        currSentence = nextSentence.sentence;
        currCharPosition = 0;
        name.text = nextSentence.name;
        text.characterSpacing = (nextSentence.characterSpacing <= 0) ? 4 : nextSentence.characterSpacing;
        textSpeed = (nextSentence.textSpeed <= 0) ? 0.02f : nextSentence.textSpeed;
    }

    public void EndDialogue() {
        sentences.Clear();
        dialogueBox.SetActive(false);
        nameBox.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(TalkCooldown());
    }

    private IEnumerator TalkCooldown() {
        yield return new WaitForSeconds(0.5f);
        IsTalking = false;
        canPressSpace = false;
        text.text = "";
        name.text = "";
    }
}
