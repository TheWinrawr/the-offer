using UnityEngine;
using System.Collections;

public class ProgressManager : MonoBehaviour {

    public static ProgressManager Instance { get; private set; }

    public bool BossOneBeaten { get; set; }
    public bool BossTwoBeaten { get; set; }

    public int NumTimesFed { get; set; }
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        NumTimesFed = 0;
        BossOneBeaten = false;
        BossTwoBeaten = false;
    }

}
